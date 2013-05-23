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
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRemoveChat = new System.Windows.Forms.Button();
            this.buttonAddChat = new System.Windows.Forms.Button();
            this.listBoxSelectedChats = new System.Windows.Forms.ListBox();
            this.listBoxAllChats = new System.Windows.Forms.ListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.listBoxAllContacts = new System.Windows.Forms.ListBox();
            this.listBoxSelectedContacts = new System.Windows.Forms.ListBox();
            this.buttonAddContact = new System.Windows.Forms.Button();
            this.buttonRemoveContact = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxInterval);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBoxEmail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(619, 68);
            this.panel2.TabIndex = 2;
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(90, 35);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(50, 20);
            this.textBoxInterval.TabIndex = 4;
            this.textBoxInterval.Text = "10";
            this.textBoxInterval.TextChanged += new System.EventHandler(this.textBoxInterval_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Interval (sec.)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(90, 9);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(186, 20);
            this.textBoxEmail.TabIndex = 0;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRemoveChat);
            this.panel1.Controls.Add(this.buttonAddChat);
            this.panel1.Controls.Add(this.listBoxSelectedChats);
            this.panel1.Controls.Add(this.listBoxAllChats);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 181);
            this.panel1.TabIndex = 3;
            // 
            // buttonRemoveChat
            // 
            this.buttonRemoveChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveChat.Location = new System.Drawing.Point(269, 81);
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
            this.buttonAddChat.Location = new System.Drawing.Point(269, 39);
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
            this.listBoxSelectedChats.FormattingEnabled = true;
            this.listBoxSelectedChats.Location = new System.Drawing.Point(378, 0);
            this.listBoxSelectedChats.Name = "listBoxSelectedChats";
            this.listBoxSelectedChats.Size = new System.Drawing.Size(241, 181);
            this.listBoxSelectedChats.TabIndex = 1;
            // 
            // listBoxAllChats
            // 
            this.listBoxAllChats.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxAllChats.FormattingEnabled = true;
            this.listBoxAllChats.Location = new System.Drawing.Point(0, 0);
            this.listBoxAllChats.Name = "listBoxAllChats";
            this.listBoxAllChats.Size = new System.Drawing.Size(235, 181);
            this.listBoxAllChats.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(532, 448);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // listBoxAllContacts
            // 
            this.listBoxAllContacts.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxAllContacts.FormattingEnabled = true;
            this.listBoxAllContacts.Location = new System.Drawing.Point(0, 0);
            this.listBoxAllContacts.Name = "listBoxAllContacts";
            this.listBoxAllContacts.Size = new System.Drawing.Size(235, 181);
            this.listBoxAllContacts.TabIndex = 0;
            // 
            // listBoxSelectedContacts
            // 
            this.listBoxSelectedContacts.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxSelectedContacts.FormattingEnabled = true;
            this.listBoxSelectedContacts.Location = new System.Drawing.Point(378, 0);
            this.listBoxSelectedContacts.Name = "listBoxSelectedContacts";
            this.listBoxSelectedContacts.Size = new System.Drawing.Size(241, 181);
            this.listBoxSelectedContacts.TabIndex = 1;
            // 
            // buttonAddContact
            // 
            this.buttonAddContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddContact.Location = new System.Drawing.Point(269, 39);
            this.buttonAddContact.Name = "buttonAddContact";
            this.buttonAddContact.Size = new System.Drawing.Size(75, 23);
            this.buttonAddContact.TabIndex = 5;
            this.buttonAddContact.Text = "Add >>";
            this.buttonAddContact.UseVisualStyleBackColor = true;
            this.buttonAddContact.Click += new System.EventHandler(this.buttonAddContact_Click);
            // 
            // buttonRemoveContact
            // 
            this.buttonRemoveContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveContact.Location = new System.Drawing.Point(269, 81);
            this.buttonRemoveContact.Name = "buttonRemoveContact";
            this.buttonRemoveContact.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveContact.TabIndex = 6;
            this.buttonRemoveContact.Text = "<< Remove";
            this.buttonRemoveContact.UseVisualStyleBackColor = true;
            this.buttonRemoveContact.Click += new System.EventHandler(this.buttonRemoveContact_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonRemoveContact);
            this.panel3.Controls.Add(this.buttonAddContact);
            this.panel3.Controls.Add(this.listBoxSelectedContacts);
            this.panel3.Controls.Add(this.listBoxAllContacts);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 249);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 181);
            this.panel3.TabIndex = 5;
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
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 483);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxSelectedChats;
        private System.Windows.Forms.ListBox listBoxAllChats;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonRemoveChat;
        private System.Windows.Forms.Button buttonAddChat;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.ListBox listBoxAllContacts;
        private System.Windows.Forms.ListBox listBoxSelectedContacts;
        private System.Windows.Forms.Button buttonAddContact;
        private System.Windows.Forms.Button buttonRemoveContact;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

    }
}