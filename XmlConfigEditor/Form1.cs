using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace xmlConfigEditor
{
    public partial class Form1 : Form
    {
        FindReplaceDialog findReplaceDialog1;
        const int ttStart = 250;
        XmlDocument xmlSource;
        XmlDocument xmlTarget;
        TreeNode selectedNode;
        TreeNode ttNode;
        string lastFoundPath;
        string configFileName;
        string comment = string.Empty;
        Point menuPosition;
        Timer ttTimer;
        ToolTip tt;
        Boolean newSearch;
        Boolean replace;
        Boolean replaceAll;
        Boolean fileDirty;

        public Form1()
        {
            InitializeComponent();
            ttTimer = new Timer();
            tt = new ToolTip();
            ttTimer.Tick += ttTimer_Tick;
            this.Resize += Form1_Resize;
            sourceTreeView.Scroll += TreeView_Scroll;
            sourceTreeView.NodeMouseHover += TreeView_NodeMouseHover;
            sourceTreeView.NodeMouseClick += TreeView_NodeMouseClick;
            sourceTreeView.MouseLeave += TreeView_MouseLeave;
            sourceTreeView.MouseUp += TreeView_MouseUp;
            targetTreeView.Scroll += TreeView_Scroll;
            targetTreeView.NodeMouseHover += TreeView_NodeMouseHover;
            targetTreeView.NodeMouseClick += TreeView_NodeMouseClick;
            targetTreeView.MouseLeave += TreeView_MouseLeave;
            targetTreeView.MouseUp += TreeView_MouseUp;
            findReplaceDialog1 = new FindReplaceDialog();
            findReplaceDialog1.DisableUpDown = true;
            findReplaceDialog1.Direction = FindDirection.Down;
            findReplaceDialog1.FindWhat = "";
            findReplaceDialog1.ReplaceWith = "";
            findReplaceDialog1.FindNext += findReplaceDialog1_FindNext;
            findReplaceDialog1.Replace += findReplaceDialog1_Replace;
            findReplaceDialog1.ReplaceAll += findReplaceDialog1_ReplaceAll;
            findReplaceDialog1.DialogTerminate += findReplaceDialog1_Close;
        }

        #region "Event Handlers"
        void Form1_Resize(object sender, EventArgs e)
        {
            sourceTreeView.Top = 56;
            sourceTreeView.Left = 13;
            targetTreeView.Top = 56;
            targetTreeView.Top = 56;
            sourceTreeView.Height = this.Height - 100;
            targetTreeView.Height = sourceTreeView.Height;
            if (targetTreeView.Visible)
            {
                sourceTreeView.Width = ((int)(this.Width / 2) - 26);
                targetTreeView.Width = sourceTreeView.Width;
                targetTreeView.Left = sourceTreeView.Width + 26;
            }
            else
            {
                sourceTreeView.Width = this.Width - 36;
            }
        }

        void ttTimer_Tick(object sender, EventArgs e)
        {
            ttTimer.Stop();
            if (ttNode.ToolTipText != string.Empty)
            {
                Point mousePos = sourceTreeView.PointToClient(MousePosition);
                if (ttNode.Bounds.Contains(mousePos))
                {
                    Point loc = ttNode.Bounds.Location;
                    loc.Offset(sourceTreeView.Location);
                    loc.Offset(ttNode.Bounds.Width - 7, -12);
                    tt.Show(ttNode.ToolTipText, this, loc);
                }
            }
        }

        void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fOpen = new OpenFileDialog();
            fOpen.Title = "Open Config File";
            fOpen.Filter = "XML Files|*.xml|All Files|*.*";
            fOpen.FilterIndex = 0;
            if (fOpen.ShowDialog() == DialogResult.OK)
            {
                configFileName = fOpen.FileName.ToString();
                xmlSource = new XmlDocument();

                int i = configFileName.LastIndexOf("-") + 1;
                int j = configFileName.LastIndexOf(".");
                if (i > 0)
                {
                    txtServerName.Text = configFileName.Substring(i, j - i);
                }
                XmlTextReader reader = new XmlTextReader(configFileName);
                reader.Read();
                xmlSource.Load(reader);
                reader.Close();

                sourceTreeView.Nodes.Clear();
                TreeNode tn = new TreeNode(xmlSource.DocumentElement.Name);
                tn.Tag = "/" + xmlSource.DocumentElement.Name;
                tn.ContextMenuStrip = treeContextMenu;
                sourceTreeView.Nodes.Add(tn);
                addNode(xmlSource.DocumentElement, tn);
                tn.Expand();
                lblServerName.Enabled = true;
                txtServerName.Enabled = true;
                compareToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                findToolStripMenuItem.Enabled = true;
                replaceToolStripMenuItem.Enabled = true;
                fileDirty = false;
            }

        }

        void compareTrees_Click(object sender, EventArgs e)
        {
            OpenFileDialog fOpen = new OpenFileDialog();
            fOpen.Title = "Compare Config File";
            fOpen.Filter = "XML Files|*.xml|All Files|*.*";
            fOpen.FilterIndex = 0;
            if (fOpen.ShowDialog() == DialogResult.OK)
            {
                string comparefilename = fOpen.FileName.ToString();
                xmlTarget = new XmlDocument();
                XmlTextReader reader = new XmlTextReader(comparefilename);
                reader.Read();
                xmlTarget.Load(reader);
                reader.Close();

                targetTreeView.Nodes.Clear();
                TreeNode tn = new TreeNode(xmlTarget.DocumentElement.Name);
                tn.Tag = "/" + xmlTarget.DocumentElement.Name;
                targetTreeView.Nodes.Add(tn);
                addNode(xmlTarget.DocumentElement, tn);
                tn.Expand();
                sourceTreeView.Width = ((int)(this.Width / 2) - 25);
                targetTreeView.Width = sourceTreeView.Width;
                targetTreeView.Left = sourceTreeView.Width + 25;
                targetTreeView.Visible = true;
                compareNode(sourceTreeView.TopNode, targetTreeView.TopNode);
                sourceTreeView.Nodes[0].EnsureVisible();
                targetTreeView.Nodes[0].EnsureVisible();
            }
        }

        void saveButton_Click(object sender, EventArgs e)
        {
            saveChange();
            int i = configFileName.LastIndexOf("-") + 1;
            int j = configFileName.LastIndexOf(".");

            SaveFileDialog fSave = new SaveFileDialog();
            fSave.Title = "Save XML Config File";
            fSave.Filter = "XML Files|*.xml|All Files|*.*";
            fSave.FilterIndex = 0;

            if (txtServerName.Text.Length > 0)
            {
                if (i > 0)
                {
                    fSave.FileName = configFileName.Substring(0, i) + txtServerName.Text + ".xml";
                }
                else
                {
                    fSave.FileName = configFileName.Substring(0, j) + "-" + txtServerName.Text + ".xml";
                }
            }
            else
            {
                fSave.FileName = configFileName;
            }
            if (fSave.FileName != configFileName || sender.ToString() == "Save &As")
            {
                if (fSave.ShowDialog() == DialogResult.OK && fSave.FileName != "")
                {
                    //Update XML config file with DOM changes
                    updateXml();
                    //Save XML config file
                    xmlSource.Save(fSave.FileName);
                }
            }
            else
            {
                updateXml();
                xmlSource.Save(configFileName);
            }
            fileDirty = false;
        }

        void TreeView_MouseLeave(object sender, EventArgs e)
        {
            ttTimer.Stop();
            tt.Hide(this);
        }

        void TreeView_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            ttTimer.Stop();
            tt.Hide(this);
            ttNode = e.Node;
            ttTimer.Interval = ttStart;
            ttTimer.Start();
        }

        void TreeView_Scroll(object sender, ScrollTreeVw.ScrollEventArgs e)
        {
            if (selectedNode != null)
            {
                saveChange();
            }
        }

        void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tn = e.Node;
            openNode(tn);
        }

        void openNode(TreeNode tn)
        {
            TreeView tv = tn.TreeView;
            // If a Node is Opened for editing Save Changes before opening new node
            if (selectedNode != null) saveChange();
            selectedNode = tn;
            if (tn.Nodes != null && tn.Nodes.Count == 0)
            {
                // Use DropDown for True/False entries except Provision element
                if ((tn.Text.ToLower() == "true" || tn.Text.ToLower() == "false") && (tn.Parent.Text != "Provision"))
                {
                    TfValue.Top = tn.Bounds.Top + tv.Top;
                    TfValue.Left = tn.Bounds.Left + tv.Left;
                    TfValue.Text = tn.Text;
                    TfValue.Visible = true;
                    TfValue.BringToFront();
                }
                // Use Textbox for all other Elements or Attributes
                else
                {
                    value.Top = tn.Bounds.Top + tv.Top;
                    value.Left = tn.Bounds.Left + tv.Left;
                    int width = tn.Bounds.Width + 25;
                    if (width > 120)
                    {
                        value.Width = tn.Bounds.Width + 25;
                    }
                    else
                    {
                        value.Width = 120;
                    }
                    //@@@ Does this need special characters
                    if (tn.Text != "null")
                    {
                        value.Text = tn.Text;
                    }
                    else
                    {
                        value.Text = string.Empty;
                    }
                    value.Visible = true;
                    value.BringToFront();
                }
            }
        }

        void TreeView_MouseUp(object sender, MouseEventArgs e)
        {
            menuPosition = e.Location;
        }

        void copyBranch_Click(object sender, EventArgs e)
        {
            fileDirty = true;
            TreeNode tn = getContextMenuNode(sender);
            TreeView tv = tn.TreeView;
            TreeNode parentNode = tn.Parent;
            saveNode(parentNode);
            string xpath = tn.Tag.ToString();
            XmlNode xNode;
            if (tv.Name.StartsWith("source"))
            {
                xNode = xmlSource.SelectSingleNode(xpath);
            }
            else
            {
                xNode = xmlTarget.SelectSingleNode(xpath);
            }
            XmlNode xParent = xNode.ParentNode;
            XmlNode newNode = xNode.Clone();
            xParent.AppendChild(newNode);
            parentNode.Nodes.Clear();
            addNode(xNode.ParentNode, parentNode);
        }

        void deleteBranch_Click(object sender, EventArgs e)
        {
            fileDirty = true;
            TreeNode tn = getContextMenuNode(sender);
            TreeView tv = tn.TreeView;
            TreeNode parentNode = tn.Parent;
            saveNode(parentNode);
            string xpath = tn.Tag.ToString();
            XmlNode xNode;
            if (tv.Name.StartsWith("source"))
            {
                xNode = xmlSource.SelectSingleNode(xpath);
            }
            else
            {
                xNode = xmlTarget.SelectSingleNode(xpath);
            }
            XmlNode xParent = xNode.ParentNode;
            xParent.RemoveChild(xNode);
            if (xParent.ChildNodes.Count == 0)
            {
                xParent.InnerText = string.Empty;
            }
            parentNode.Nodes.Clear();
            addNode(xParent, parentNode);
        }

        void deleteAttrib_Click(object sender, EventArgs e)
        {
            fileDirty = true;
            TreeNode tn = getContextMenuNode(sender);
            TreeView tv = tn.TreeView;
            TreeNode parentNode = tn.Parent;
            saveNode(parentNode);
            string xpath = tn.Tag.ToString();
            XmlNode xNode;
           if (tv.Name.StartsWith("source"))
            {
                xNode = xmlSource.SelectSingleNode(xpath);
            }
            else
            {
                xNode = xmlTarget.SelectSingleNode(xpath);
            }
           xNode.Attributes.RemoveNamedItem(tn.Text);
           parentNode.Nodes.Remove(tn);
        }
        private void expandBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = getContextMenuNode(sender);
            tn.ExpandAll();
        }

        private void contractBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = getContextMenuNode(sender);
            tn.Collapse();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to Save your Changes?", "Save Changes");
                if (result == DialogResult.OK)
                {
                    saveChange();
                    int i = configFileName.LastIndexOf("-") + 1;
                    int j = configFileName.LastIndexOf(".");

                    SaveFileDialog fSave = new SaveFileDialog();
                    fSave.Title = "Save XML Config File";
                    fSave.Filter = "XML Files|*.xml|All Files|*.*";
                    fSave.FilterIndex = 0;

                    if (txtServerName.Text.Length > 0)
                    {
                        if (i > 0)
                        {
                            fSave.FileName = configFileName.Substring(0, i) + txtServerName.Text + ".xml";
                        }
                        else
                        {
                            fSave.FileName = configFileName.Substring(0, j) + "-" + txtServerName.Text + ".xml";
                        }
                    }
                    else
                    {
                        fSave.FileName = configFileName;
                    }
                    if (fSave.FileName != configFileName)
                    {
                        if (fSave.ShowDialog() == DialogResult.OK && fSave.FileName != "")
                        {
                            //Update XML config file with DOM changes
                            updateXml();
                            //Save XML config file
                            xmlSource.Save(fSave.FileName);
                        }
                    }
                    else
                    {
                        updateXml();
                        xmlSource.Save(configFileName);
                    }

                }
            }

            this.Close();
        }

        private void find_Click(object sender, EventArgs e)
        {
            findReplaceDialog1.Type = FindReplaceDialogType.Find;
            findReplaceDialog1.ShowDialog(this);
        }

        private void replace_Click(object sender, EventArgs e)
        {
            findReplaceDialog1.Type = FindReplaceDialogType.Replace;
            findReplaceDialog1.ShowDialog(this);
        }

        void findReplaceDialog1_Close(object sender, EventArgs e)
        {
            findReplaceDialog1.FindWhat = "";
            findReplaceDialog1.ReplaceWith = "";
            lastFoundPath = "";
            updateXml();
        }

        void findReplaceDialog1_ReplaceAll(object sender, EventArgs e)
        {
            replace = true;
            replaceAll = true;
            newSearch = false;
            Boolean result;
            do
            {
                result = searchNodes(sourceTreeView.TopNode);
            } while (result);
        }

        void findReplaceDialog1_Replace(object sender, EventArgs e)
        {
            replace = true;
            replaceAll = false;
            newSearch = false;
            Boolean result = searchNodes(sourceTreeView.TopNode);
            if (!result)
            {
                MessageBox.Show(string.Format("Cannot find \"{0}\"", findReplaceDialog1.FindWhat), "XmlConfigEditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lastFoundPath = string.Empty;
            }
        }

        void findReplaceDialog1_FindNext(object sender, EventArgs e)
        {

            replace = false;
            replaceAll = false;
            newSearch = false;
            Boolean result = searchNodes(sourceTreeView.TopNode);
            if (!result)
            {
                MessageBox.Show(string.Format("Cannot find \"{0}\"", findReplaceDialog1.FindWhat), "XmlConfigEditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lastFoundPath = string.Empty;
            }
        }

        void insertElement_Click(object sender, EventArgs e)
        {
            fileDirty = true;
            string nodeName = string.Empty;
            string nodeValue = string.Empty;
            getElementValues(out  nodeName, out  nodeValue);
            if (string.IsNullOrEmpty(nodeName)) return;

            TreeNode tn = getContextMenuNode(sender);
            TreeView tv = tn.TreeView;
            string xpath = tn.Tag.ToString();
            XmlNode xNode;
            if (tv.Name.StartsWith("source"))
            {
                xNode = xmlSource.SelectSingleNode(xpath);
            }
            else
            {
                xNode = xmlTarget.SelectSingleNode(xpath);
            }
            XmlNode newNode;
            if (tv.Name.StartsWith("source"))
            {
                newNode = xmlSource.CreateElement(nodeName, null);
            }
            else
            {
                newNode = xmlTarget.CreateNode(XmlNodeType.Element, nodeName, null);
            }
            if (!string.IsNullOrEmpty(nodeValue))
            {
                newNode.InnerText = nodeValue;
            }
            else
            {
                newNode.InnerText = "null";
            }
            xNode.AppendChild(newNode);
            tn.Nodes.Clear();
            addNode(xNode, tn);
            selectedNode = tn;
        }

        void addAttribute_Click(object sender, EventArgs e)
        {
            fileDirty = true;
            TreeNode tn = getContextMenuNode(sender);
            TreeView tv = tn.TreeView;
            string nodeName = string.Empty;
            string nodeValue = string.Empty;
            getElementValues(out  nodeName, out  nodeValue);
            if (string.IsNullOrEmpty(nodeName)) return;
            string xpath = tn.Tag.ToString();
            XmlElement xNode;
            XmlAttribute newAttrib;
            if (tv.Name.StartsWith("source"))
            {
                xNode = xmlSource.SelectSingleNode(xpath) as XmlElement;
                newAttrib = xmlSource.CreateAttribute(nodeName);
                newAttrib.Value = nodeValue;
            }
            else
            {
                xNode = xmlTarget.SelectSingleNode(xpath) as XmlElement;
                newAttrib = xmlTarget.CreateAttribute(nodeName);
                newAttrib.Value = nodeValue;
            }
            xNode.Attributes.Append(newAttrib);
            tn.Nodes.Clear();
            addNode(xNode, tn);
        }
        #endregion


        #region "Helper Methods"
        Boolean searchNodes(TreeNode tn)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (lastFoundPath == null || lastFoundPath == string.Empty) newSearch = true;
            Boolean found = false;
            //Search All Child Nodes
            for (int i = 0; i < tn.Nodes.Count; i++)
            {
                //Get next Node to check
                TreeNode tn1 = searchNode(tn.Nodes[i]);
                if (tn1 != null)  //A Node was found
                {
                    sourceTreeView.SelectedNode = tn1;

                    openNode(sourceTreeView.SelectedNode);
                    tn1.EnsureVisible();

                    if (newSearch)
                    {
                        found = true;
                        if (replace)
                        {
                            int start = sourceTreeView.SelectedNode.Text.IndexOf(findReplaceDialog1.FindWhat, StringComparison.CurrentCultureIgnoreCase);
                            int length = findReplaceDialog1.FindWhat.Length;
                            value.Text = string.Format("{0}{1}{2}", sourceTreeView.SelectedNode.Text.Substring(0, start), findReplaceDialog1.ReplaceWith, sourceTreeView.SelectedNode.Text.Substring(start + length));
                            if (replaceAll)
                            {
                                tn1.Text = value.Text;
                                saveNode(tn1);
                            }
                            lastFoundPath = tn1.FullPath;
                            fileDirty = true;
                        }
                        if (replaceAll == false) break;
                    }
                    else if (tn1.FullPath == lastFoundPath)
                    {
                        newSearch = true;
                        found = false;
                    }

                }
                else if (!found && tn.Nodes[i].Nodes.Count > 0)
                {
                    found = searchNodes(tn.Nodes[i]);
                }
            }
            Cursor.Current = Cursors.Default;
            return found;
        }

        TreeNode searchNode(TreeNode tn)
        {
            string target = findReplaceDialog1.FindWhat;

            //if this is a leaf Node check it otherwise return NULL
            if (tn.Nodes.Count == 1 && tn.Nodes[0].Nodes.Count == 0) //this is a leaf Node
            {
                if (findReplaceDialog1.MatchWholeWord)
                {
                    if (findReplaceDialog1.MatchCase)
                    {
                        if (tn.Nodes[0].Text.Equals(target, StringComparison.CurrentCulture))
                        {
                            return tn.Nodes[0];
                        }
                    }
                    else
                    {
                        if (tn.Nodes[0].Text.Equals(target, StringComparison.CurrentCultureIgnoreCase))
                        {
                            return tn.Nodes[0];
                        }
                    }
                }
                else
                {

                    if (findReplaceDialog1.MatchCase)
                    {
                        if (tn.Nodes[0].Text.IndexOf(target, StringComparison.CurrentCulture) >= 0)
                        {
                            return tn.Nodes[0];
                        }
                    }
                    else
                    {
                        if (tn.Nodes[0].Text.IndexOf(target, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            return tn.Nodes[0];
                        }
                    }
                }
            }
            return null;
        }

        TreeNode getContextMenuNode(object sender)
        {
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            TreeView tv = (TreeView)cms.SourceControl;
            return tv.GetNodeAt(menuPosition);
        }

        void addNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i;
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                int j = 0;
                if (inXmlNode.Attributes != null && inXmlNode.Attributes.Count > 0)
                {

                    for (i = 0; i <= inXmlNode.Attributes.Count - 1; i++)
                    {
                        TreeNode attribNode = new TreeNode(inXmlNode.Attributes[i].Name);
                        inTreeNode.Nodes.Add(attribNode);
                        attribNode.Tag = inTreeNode.Tag + "[@" + inXmlNode.Attributes[i].Name + "]";
                        attribNode.BackColor = Color.LightGray;
                        attribNode.ContextMenuStrip = nodeContextMenu3;
                        TreeNode attribValue = new TreeNode(removeSpecialChar(inXmlNode.Attributes[i].Value));
                        attribNode.Nodes.Add(attribValue);
                        attribValue.Tag = inTreeNode.Tag + "[@" + inXmlNode.Attributes[i].Name + "]";

                    }
                }
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];

                    if ((xNode.NodeType != XmlNodeType.Comment)
                        && ((xmlConfigEditor.Properties.Settings.Default.clonableNodes.Contains(xNode.Name) || xNode.ParentNode.Name == xNode.Name + "s")
                        || (xNode.PreviousSibling != null && xNode.PreviousSibling.Name == xNode.Name)
                        || (xNode.NextSibling != null && xNode.Name == xNode.NextSibling.Name)))
                    {
                        if (xNode.PreviousSibling == null || xNode.PreviousSibling.Name != xNode.Name) j = 0;
                        j++;
                    }
                    else
                    {
                        j = 0;
                    }
                    if (xNode.NodeType == XmlNodeType.Comment)
                    {
                        comment = xNode.InnerText;
                    }
                    else
                    {
                        if (xNode.NodeType == XmlNodeType.Text)
                        {
                            tNode = new TreeNode(removeSpecialChar(xNode.Value));
                            inTreeNode.Nodes.Add(tNode);
                            tNode.Tag = tNode.Parent.Tag;
                            tNode.ToolTipText = comment;
                            comment = string.Empty;
                            if (tNode.Text == string.Empty) tNode.Text = "null";
                        }
                        else
                        {
                            tNode = new TreeNode(xNode.Name);
                            inTreeNode.Nodes.Add(tNode);
                            if (j > 0)
                            {
                                tNode.ContextMenuStrip = nodeContextMenu;

                            }
                            else
                            {
                                tNode.ContextMenuStrip = nodeContextMenu2;
                            }
                            if (xNode.HasChildNodes || xNode.Value == null)
                            {
                                if (j > 0)
                                {
                                    tNode.Tag = string.Format("{0}/{1}[{2}]", tNode.Parent.Tag, xNode.Name, j);
                                }
                                else
                                {
                                    tNode.Tag = string.Format("{0}/{1}", tNode.Parent.Tag, xNode.Name);
                                }
                                if (!xNode.HasChildNodes && xNode.Value == null && !xNode.OuterXml.Contains("/>"))
                                {
                                    TreeNode vNode = new TreeNode("null");
                                    tNode.Nodes.Add(vNode);
                                    vNode.Tag = tNode.Tag;
                                }
                            }
                            tNode.ToolTipText = comment;
                            if (j > 1) tNode.ToolTipText = tNode.PrevNode.ToolTipText;
                            comment = string.Empty;
                        }


                        addNode(xNode, tNode);

                    }
                }

            }
            else
            {
                // Here you need to pull the data from the XmlNode based on the
                // type of node, whether attribute values are required, and so forth.
                if (inXmlNode.NodeType == XmlNodeType.Comment)
                {
                    comment = inXmlNode.InnerText;
                }
                else
                {
                    if (inXmlNode.Attributes != null && inXmlNode.Attributes.Count > 0)
                    {
                        for (i = 0; i <= inXmlNode.Attributes.Count - 1; i++)
                        {
                            TreeNode attribNode = new TreeNode(inXmlNode.Attributes[i].Name);
                            attribNode.Tag = inTreeNode.Tag + "[@" + inXmlNode.Attributes[i].Name + "]";
                            attribNode.BackColor = Color.LightGray;
                            attribNode.ContextMenuStrip = nodeContextMenu3;
                            inTreeNode.Nodes.Add(attribNode);
                            TreeNode attribValue = new TreeNode(removeSpecialChar(inXmlNode.Attributes[i].Value));
                            attribNode.Nodes.Add(attribValue);
                            attribValue.Tag = inTreeNode.Tag + "[@" + inXmlNode.Attributes[i].Name + "]";
                        }
                    }
                }
            }
        }

        void saveNode(TreeNode tn)
        {
            string xpath = tn.Tag.ToString();

            XmlNode node = xmlSource.SelectSingleNode(xpath);
            //Save as Attribute
            if (xpath.Contains("@"))
            {
                string attribname = xpath.Substring(xpath.IndexOf("@") + 1);
                attribname = attribname.Substring(0, attribname.Length - 1);
                if (attribname != tn.Text)
                {
                    node.Attributes[attribname].InnerXml = addSpecialChar(tn.Text);
                }
            }
            else
            {
                if (node.LocalName != tn.Text) //&& node.InnerText != ""
                {
                    XmlNode textNode = node.SelectSingleNode("./text()");
                    if (textNode != null)
                    {
                        if (tn.Text != "null")
                        {
                            //need to handle special char here
                            string test = addSpecialChar(tn.Text);
                            textNode.Value = test;
                        }
                        else
                        {
                            textNode.Value = string.Empty;
                        }
                    }
                }
            }
            if (tn.Nodes.Count > 0)
            {
                for (int i = 0; i < tn.Nodes.Count; i++)
                {
                    TreeNode tnChild = tn.Nodes[i];
                    saveNode(tnChild);
                }
            }

        }

        void updateXml()
        {
            for (int i = 0; i < sourceTreeView.Nodes.Count; i++)
            {
                TreeNode tn = sourceTreeView.Nodes[i];
                saveNode(tn);
            }

        }

        void saveChange()
        {
            if (selectedNode != null)
            {
                if (value.Visible == true)
                {
                    if (selectedNode.Text != value.Text)
                    {
                        fileDirty = true;
                        if (value.Text == string.Empty)
                        {
                            selectedNode.Text = "null";
                        }
                        else
                        {
                            selectedNode.Text = value.Text;
                        }
                    }
                    selectedNode = null;
                    value.Visible = false;
                    value.Text = string.Empty;
                }
                else if (TfValue.Visible == true)
                {
                    fileDirty = true;
                    selectedNode.Text = TfValue.Text;
                    TfValue.Visible = false;
                    selectedNode = null;
                }
                sourceTreeView.Scrollable = true;
            }
        }

        string addSpecialChar(string stringin)
        {
            StringBuilder returnValue = new StringBuilder();
            int charLeft;
            for (int i = 0; i < stringin.Length; i++)
            {
                charLeft = stringin.Length - i;
                if (stringin.Substring(i, 1) == "&")
                {
                    returnValue.Append("&amp;");
                }
                else if (stringin.Substring(i, 1) == "'")
                {
                    returnValue.Append("&apos;");
                }
                else if (stringin.Substring(i, 1) == "\"")
                {
                    returnValue.Append("&quot;");
                }
                else if (stringin.Substring(i, 1) == "<")
                {
                    returnValue.Append("&lt;");
                }
                else if (stringin.Substring(i, 1) == ">")
                {
                    returnValue.Append("&gt;");
                }
                else
                {
                    returnValue.Append(stringin.Substring(i, 1));
                }
            }

            return returnValue.ToString();
        }

        string removeSpecialChar(string stringin)
        {
            StringBuilder returnValue = new StringBuilder();
            int charLeft;

            for (int i = 0; i < stringin.Length; i++)
            {
                charLeft = stringin.Length - i;
                if (charLeft > 6 && stringin.Substring(i, 6) == "&apos;")
                {
                    returnValue.Append("'");
                    i = i + 6;
                }
                else if (charLeft > 6 && stringin.Substring(i, 6) == "&quot;")
                {
                    returnValue.Append("\"");
                    i = i + 6;
                }
                else if (charLeft > 4 && stringin.Substring(i, 4) == "&lt;")
                {
                    returnValue.Append("<");
                    i = i + 4;
                }
                else if (charLeft > 4 && stringin.Substring(i, 4) == "&gt;")
                {
                    stringin = stringin.Replace("&gt;", ">");
                    returnValue.Append(">");
                    i = i + 4;
                }
                else if (charLeft > 5 && stringin.Substring(i, 5) == "&amp;")
                {
                    returnValue.Append("&");
                }
                else
                {
                    returnValue.Append(stringin.Substring(i, 1));
                }
            }
            return returnValue.ToString();
        }

        int compareNode(TreeNode sourceNode, TreeNode targetNode)
        {
            int result = 0;
            // Source and Target elements match
            if (sourceNode.Text == targetNode.Text)
            {
                //Source only Contains Leaf node
                if (sourceNode.Nodes.Count == 1 && targetNode.Nodes.Count == 1)
                {
                    if (sourceNode.Nodes[0].Text != targetNode.Nodes[0].Text)
                    {
                        sourceNode.Nodes[0].BackColor = Color.Yellow;
                        targetNode.Nodes[0].BackColor = Color.Yellow;
                        expandToRoot(sourceNode.Nodes[0]);
                        expandToRoot(targetNode.Nodes[0]);
                    }
                }
            }
            //Source and Target elements don't match
            else
            {
                //Source == next Target - Target Added
                if (targetNode.NextNode != null && sourceNode.Text == targetNode.NextNode.Text)
                {
                    targetNode.BackColor = Color.LightPink;
                    return -1;
                }
                //Target == next Source - Source Added
                else if (sourceNode.NextNode != null && targetNode.Text == sourceNode.NextNode.Text)
                {
                    sourceNode.BackColor = Color.LightGreen;
                    return 0;
                }
                //Source and Target don't match at all Both added
                else
                {
                    sourceNode.BackColor = Color.LightGreen;
                    targetNode.BackColor = Color.LightPink;
                    return 1;
                }

            }
            //Call compare recursively
            if ((sourceNode.Nodes.Count > 1 || targetNode.Nodes.Count > 1) && sourceNode.Text == targetNode.Text)
            {
                int j, l = 0;
                for (int k = 0; k < sourceNode.Nodes.Count; k++)
                {
                    if (targetNode.Nodes.Count > l)
                    {
                        j = compareNode(sourceNode.Nodes[k], targetNode.Nodes[l]);
                        if (j < 0) { k = k + j; }
                        l++;
                    }
                }
            }
            return result;
        }

        void expandToRoot(TreeNode tn)
        {
            if (!tn.Parent.IsExpanded)
            {
                tn.Parent.Expand();
                expandToRoot(tn.Parent);
            }
        }

        public void getElementValues(out string nodeName, out string nodeValue)
        {
            Form2 testDialog = new Form2();

            nodeName = string.Empty;
            nodeValue = string.Empty;

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                nodeName = testDialog.txtNodeName.Text;
                nodeValue = testDialog.txtNodeValue.Text;
            }
            else
            {
                //do nothing
            }
            testDialog.Dispose();
        }
        #endregion

    }
}
