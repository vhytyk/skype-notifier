namespace SkypeNotifier
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.buttonSave = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.settingsGrid = new System.Windows.Forms.PropertyGrid();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonRemoveContact = new System.Windows.Forms.Button();
            this.buttonAddContact = new System.Windows.Forms.Button();
            this.listBoxSelectedContacts = new System.Windows.Forms.ListBox();
            this.listBoxAllContacts = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRemoveChat = new System.Windows.Forms.Button();
            this.buttonAddChat = new System.Windows.Forms.Button();
            this.listBoxSelectedChats = new System.Windows.Forms.ListBox();
            this.listBoxAllChats = new System.Windows.Forms.ListBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxFilterChats = new System.Windows.Forms.TextBox();
            this.textBoxFilterContact = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Enabled = false;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(446, 339);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(125, 42);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Skype notifier";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(583, 325);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(575, 299);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Subscriptions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.settingsGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(575, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // settingsGrid
            // 
            this.settingsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsGrid.Location = new System.Drawing.Point(3, 3);
            this.settingsGrid.Name = "settingsGrid";
            this.settingsGrid.Size = new System.Drawing.Size(569, 293);
            this.settingsGrid.TabIndex = 2;
            this.settingsGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.settingsGrid_PropertyValueChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(569, 293);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBoxFilterContact);
            this.panel3.Controls.Add(this.buttonRemoveContact);
            this.panel3.Controls.Add(this.buttonAddContact);
            this.panel3.Controls.Add(this.listBoxSelectedContacts);
            this.panel3.Controls.Add(this.listBoxAllContacts);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(569, 148);
            this.panel3.TabIndex = 7;
            // 
            // buttonRemoveContact
            // 
            this.buttonRemoveContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveContact.Location = new System.Drawing.Point(242, 79);
            this.buttonRemoveContact.Name = "buttonRemoveContact";
            this.buttonRemoveContact.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveContact.TabIndex = 6;
            this.buttonRemoveContact.Text = "<< Remove";
            this.buttonRemoveContact.UseVisualStyleBackColor = true;
            this.buttonRemoveContact.Click += new System.EventHandler(this.buttonRemoveContact_Click);
            // 
            // buttonAddContact
            // 
            this.buttonAddContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddContact.Location = new System.Drawing.Point(242, 37);
            this.buttonAddContact.Name = "buttonAddContact";
            this.buttonAddContact.Size = new System.Drawing.Size(75, 23);
            this.buttonAddContact.TabIndex = 5;
            this.buttonAddContact.Text = "Add >>";
            this.buttonAddContact.UseVisualStyleBackColor = true;
            this.buttonAddContact.Click += new System.EventHandler(this.buttonAddContact_Click);
            // 
            // listBoxSelectedContacts
            // 
            this.listBoxSelectedContacts.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxSelectedContacts.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSelectedContacts.FormattingEnabled = true;
            this.listBoxSelectedContacts.ItemHeight = 16;
            this.listBoxSelectedContacts.Location = new System.Drawing.Point(328, 0);
            this.listBoxSelectedContacts.Name = "listBoxSelectedContacts";
            this.listBoxSelectedContacts.Size = new System.Drawing.Size(241, 148);
            this.listBoxSelectedContacts.TabIndex = 1;
            // 
            // listBoxAllContacts
            // 
            this.listBoxAllContacts.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAllContacts.FormattingEnabled = true;
            this.listBoxAllContacts.ItemHeight = 16;
            this.listBoxAllContacts.Location = new System.Drawing.Point(0, 23);
            this.listBoxAllContacts.Name = "listBoxAllContacts";
            this.listBoxAllContacts.Size = new System.Drawing.Size(235, 132);
            this.listBoxAllContacts.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxFilterChats);
            this.panel1.Controls.Add(this.buttonRemoveChat);
            this.panel1.Controls.Add(this.buttonAddChat);
            this.panel1.Controls.Add(this.listBoxSelectedChats);
            this.panel1.Controls.Add(this.listBoxAllChats);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 142);
            this.panel1.TabIndex = 6;
            // 
            // buttonRemoveChat
            // 
            this.buttonRemoveChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveChat.Location = new System.Drawing.Point(242, 74);
            this.buttonRemoveChat.Name = "buttonRemoveChat";
            this.buttonRemoveChat.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveChat.TabIndex = 6;
            this.buttonRemoveChat.Text = "<< Remove";
            this.buttonRemoveChat.UseVisualStyleBackColor = true;
            this.buttonRemoveChat.Click += new System.EventHandler(this.buttonRemoveChat_Click);
            // 
            // buttonAddChat
            // 
            this.buttonAddChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddChat.Location = new System.Drawing.Point(242, 32);
            this.buttonAddChat.Name = "buttonAddChat";
            this.buttonAddChat.Size = new System.Drawing.Size(75, 23);
            this.buttonAddChat.TabIndex = 5;
            this.buttonAddChat.Text = "Add >>";
            this.buttonAddChat.UseVisualStyleBackColor = true;
            this.buttonAddChat.Click += new System.EventHandler(this.buttonAddChat_Click);
            // 
            // listBoxSelectedChats
            // 
            this.listBoxSelectedChats.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxSelectedChats.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSelectedChats.FormattingEnabled = true;
            this.listBoxSelectedChats.ItemHeight = 16;
            this.listBoxSelectedChats.Location = new System.Drawing.Point(328, 0);
            this.listBoxSelectedChats.Name = "listBoxSelectedChats";
            this.listBoxSelectedChats.Size = new System.Drawing.Size(241, 142);
            this.listBoxSelectedChats.TabIndex = 1;
            // 
            // listBoxAllChats
            // 
            this.listBoxAllChats.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAllChats.FormattingEnabled = true;
            this.listBoxAllChats.ItemHeight = 16;
            this.listBoxAllChats.Location = new System.Drawing.Point(0, 24);
            this.listBoxAllChats.Name = "listBoxAllChats";
            this.listBoxAllChats.Size = new System.Drawing.Size(235, 116);
            this.listBoxAllChats.TabIndex = 0;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(12, 348);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(69, 26);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // textBoxFilterChats
            // 
            this.textBoxFilterChats.Location = new System.Drawing.Point(0, 3);
            this.textBoxFilterChats.Name = "textBoxFilterChats";
            this.textBoxFilterChats.Size = new System.Drawing.Size(235, 20);
            this.textBoxFilterChats.TabIndex = 7;
            this.textBoxFilterChats.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFilterChats_KeyUp);
            // 
            // textBoxFilterContact
            // 
            this.textBoxFilterContact.Location = new System.Drawing.Point(0, 3);
            this.textBoxFilterContact.Name = "textBoxFilterContact";
            this.textBoxFilterContact.Size = new System.Drawing.Size(235, 20);
            this.textBoxFilterContact.TabIndex = 8;
            this.textBoxFilterContact.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFilterContact_KeyUp);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 393);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.Text = "Skype Notifier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PropertyGrid settingsGrid;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonRemoveContact;
        private System.Windows.Forms.Button buttonAddContact;
        private System.Windows.Forms.ListBox listBoxSelectedContacts;
        private System.Windows.Forms.ListBox listBoxAllContacts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRemoveChat;
        private System.Windows.Forms.Button buttonAddChat;
        private System.Windows.Forms.ListBox listBoxSelectedChats;
        private System.Windows.Forms.ListBox listBoxAllChats;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxFilterContact;
        private System.Windows.Forms.TextBox textBoxFilterChats;

    }
}