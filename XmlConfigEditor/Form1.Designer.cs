namespace xmlConfigEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.value = new System.Windows.Forms.TextBox();
            this.TfValue = new System.Windows.Forms.ComboBox();
            this.nodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandBranchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contractBranchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBranchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InsertNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.compareTreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeContextMenu2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertNodeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.addAttributeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblServerName = new System.Windows.Forms.Label();
            this.sourceTreeView = new xmlConfigEditor.ScrollTreeVw();
            this.targetTreeView = new xmlConfigEditor.ScrollTreeVw();
            this.nodeContextMenu3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeContextMenu.SuspendLayout();
            this.treeContextMenu.SuspendLayout();
            this.nodeContextMenu2.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.nodeContextMenu3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServerName
            // 
            this.txtServerName.Enabled = false;
            this.txtServerName.Location = new System.Drawing.Point(102, 27);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(175, 20);
            this.txtServerName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server Name";
            // 
            // value
            // 
            this.value.Location = new System.Drawing.Point(586, 71);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(120, 20);
            this.value.TabIndex = 4;
            this.value.Visible = false;
            // 
            // TfValue
            // 
            this.TfValue.FormattingEnabled = true;
            this.TfValue.Items.AddRange(new object[] {
            "true",
            "false"});
            this.TfValue.Location = new System.Drawing.Point(586, 97);
            this.TfValue.Name = "TfValue";
            this.TfValue.Size = new System.Drawing.Size(121, 21);
            this.TfValue.TabIndex = 5;
            this.TfValue.Visible = false;
            // 
            // nodeContextMenu
            // 
            this.nodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandBranchToolStripMenuItem,
            this.contractBranchToolStripMenuItem,
            this.copyBranch,
            this.deleteBranchToolStripMenuItem,
            this.InsertNodeToolStripMenuItem,
            this.addAttributeToolStripMenuItem});
            this.nodeContextMenu.Name = "contextmainMenu";
            this.nodeContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.nodeContextMenu.Size = new System.Drawing.Size(160, 136);
            // 
            // expandBranchToolStripMenuItem
            // 
            this.expandBranchToolStripMenuItem.Name = "expandBranchToolStripMenuItem";
            this.expandBranchToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.expandBranchToolStripMenuItem.Text = "Expand Branch";
            this.expandBranchToolStripMenuItem.Click += new System.EventHandler(this.expandBranchToolStripMenuItem_Click);
            // 
            // contractBranchToolStripMenuItem
            // 
            this.contractBranchToolStripMenuItem.Name = "contractBranchToolStripMenuItem";
            this.contractBranchToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.contractBranchToolStripMenuItem.Text = "Collapse Branch";
            this.contractBranchToolStripMenuItem.Click += new System.EventHandler(this.contractBranchToolStripMenuItem_Click);
            // 
            // copyBranch
            // 
            this.copyBranch.Name = "copyBranch";
            this.copyBranch.Size = new System.Drawing.Size(159, 22);
            this.copyBranch.Text = "&Copy Branch";
            this.copyBranch.Click += new System.EventHandler(this.copyBranch_Click);
            // 
            // deleteBranchToolStripMenuItem
            // 
            this.deleteBranchToolStripMenuItem.Name = "deleteBranchToolStripMenuItem";
            this.deleteBranchToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.deleteBranchToolStripMenuItem.Text = "&Delete Branch";
            this.deleteBranchToolStripMenuItem.Click += new System.EventHandler(this.deleteBranch_Click);
            // 
            // InsertNodeToolStripMenuItem
            // 
            this.InsertNodeToolStripMenuItem.Name = "InsertNodeToolStripMenuItem";
            this.InsertNodeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.InsertNodeToolStripMenuItem.Text = "&Insert Element";
            this.InsertNodeToolStripMenuItem.Click += new System.EventHandler(this.insertElement_Click);
            // 
            // addAttributeToolStripMenuItem
            // 
            this.addAttributeToolStripMenuItem.Name = "addAttributeToolStripMenuItem";
            this.addAttributeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addAttributeToolStripMenuItem.Text = "&Add Attribute";
            this.addAttributeToolStripMenuItem.Click += new System.EventHandler(this.addAttribute_Click);
            // 
            // treeContextMenu
            // 
            this.treeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareTreesToolStripMenuItem});
            this.treeContextMenu.Name = "treeContextMenu";
            this.treeContextMenu.Size = new System.Drawing.Size(155, 26);
            // 
            // compareTreesToolStripMenuItem
            // 
            this.compareTreesToolStripMenuItem.Name = "compareTreesToolStripMenuItem";
            this.compareTreesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.compareTreesToolStripMenuItem.Text = "Compare Trees";
            this.compareTreesToolStripMenuItem.Click += new System.EventHandler(this.compareTrees_Click);
            // 
            // nodeContextMenu2
            // 
            this.nodeContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.deleteNodeToolStripMenuItem,
            this.insertNodeToolStripMenuItem2,
            this.addAttributeToolStripMenuItem2});
            this.nodeContextMenu2.Name = "contextmainMenu";
            this.nodeContextMenu2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.nodeContextMenu2.Size = new System.Drawing.Size(160, 114);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItem1.Text = "Expand Branch";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.expandBranchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItem2.Text = "Collapse Branch";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.contractBranchToolStripMenuItem_Click);
            // 
            // deleteNodeToolStripMenuItem
            // 
            this.deleteNodeToolStripMenuItem.Name = "deleteNodeToolStripMenuItem";
            this.deleteNodeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.deleteNodeToolStripMenuItem.Text = "&Delete Node";
            this.deleteNodeToolStripMenuItem.Click += new System.EventHandler(this.deleteBranch_Click);
            // 
            // insertNodeToolStripMenuItem2
            // 
            this.insertNodeToolStripMenuItem2.Name = "insertNodeToolStripMenuItem2";
            this.insertNodeToolStripMenuItem2.Size = new System.Drawing.Size(159, 22);
            this.insertNodeToolStripMenuItem2.Text = "&Insert Element";
            this.insertNodeToolStripMenuItem2.Click += new System.EventHandler(this.insertElement_Click);
            // 
            // addAttributeToolStripMenuItem2
            // 
            this.addAttributeToolStripMenuItem2.Name = "addAttributeToolStripMenuItem2";
            this.addAttributeToolStripMenuItem2.Size = new System.Drawing.Size(159, 22);
            this.addAttributeToolStripMenuItem2.Text = "&Add Attribute";
            this.addAttributeToolStripMenuItem2.Click += new System.EventHandler(this.addAttribute_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(739, 24);
            this.mainMenu.TabIndex = 8;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.compareToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openButton_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Enabled = false;
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.compareToolStripMenuItem.Text = "&Compare";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareTrees_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.replaceToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Enabled = false;
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.find_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Enabled = false;
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+H";
            this.replaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replace_Click);
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Enabled = false;
            this.lblServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerName.Location = new System.Drawing.Point(12, 30);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(85, 13);
            this.lblServerName.TabIndex = 9;
            this.lblServerName.Text = "Target Server";
            // 
            // sourceTreeView
            // 
            this.sourceTreeView.Location = new System.Drawing.Point(13, 56);
            this.sourceTreeView.Name = "sourceTreeView";
            this.sourceTreeView.Size = new System.Drawing.Size(705, 574);
            this.sourceTreeView.TabIndex = 1;
            // 
            // targetTreeView
            // 
            this.targetTreeView.Location = new System.Drawing.Point(360, 56);
            this.targetTreeView.Name = "targetTreeView";
            this.targetTreeView.Size = new System.Drawing.Size(355, 574);
            this.targetTreeView.TabIndex = 7;
            this.targetTreeView.Visible = false;
            // 
            // nodeContextMenu3
            // 
            this.nodeContextMenu3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.nodeContextMenu3.Name = "contextmainMenu";
            this.nodeContextMenu3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.nodeContextMenu3.Size = new System.Drawing.Size(160, 70);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItem3.Text = "Expand Branch";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.expandBranchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItem4.Text = "Collapse Branch";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.contractBranchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItem5.Text = "&Delete Node";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.deleteAttrib_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 647);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.TfValue);
            this.Controls.Add(this.value);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.sourceTreeView);
            this.Controls.Add(this.targetTreeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Form1";
            this.Text = "XML Config Editor";
            this.nodeContextMenu.ResumeLayout(false);
            this.treeContextMenu.ResumeLayout(false);
            this.nodeContextMenu2.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.nodeContextMenu3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox value;
        private System.Windows.Forms.ComboBox TfValue;
        private System.Windows.Forms.ContextMenuStrip nodeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyBranch;
        private System.Windows.Forms.ToolStripMenuItem deleteBranchToolStripMenuItem;
        private ScrollTreeVw targetTreeView;
        private System.Windows.Forms.ContextMenuStrip treeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem compareTreesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandBranchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contractBranchToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip nodeContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private ScrollTreeVw sourceTreeView;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InsertNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAttributeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertNodeToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem addAttributeToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteNodeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip nodeContextMenu3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
    }
}

