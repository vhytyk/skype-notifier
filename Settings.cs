using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace SkypeNotifier
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            RefreshListBox(listBoxAllChats, SettingsManager.Instance.GetAllChats());
            RefreshListBox(listBoxSelectedChats, SettingsManager.Instance.Settings.SubscribedChats);
            RefreshListBox(listBoxAllContacts, SettingsManager.Instance.GetAllContacts());
            RefreshListBox(listBoxSelectedContacts, SettingsManager.Instance.Settings.SubscribedContacts);
            textBoxEmail.Text = SettingsManager.Instance.Settings.Email;
            textBoxInterval.Text = SettingsManager.Instance.Settings.Timer.ToString();
        }
        private void RefreshListBox(ListBox listBox, IEnumerable collection)
        {
            listBox.Items.Clear();
            foreach (var item in collection)
            {
                listBox.Items.Add(item);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SettingsManager.Instance.SaveSettings();
            buttonSave.Enabled = false;
        }

        private void buttonAddChat_Click(object sender, EventArgs e)
        {
            SkypeChat selectedChat = listBoxAllChats.SelectedItem as SkypeChat;
            if (selectedChat != null && SettingsManager.Instance.Settings.SubscribedChats.Find(chat => chat.ID == selectedChat.ID) == null)
            {
                SettingsManager.Instance.Settings.SubscribedChats.Add(selectedChat);
                listBoxSelectedChats.Items.Add(selectedChat);
                RefreshListBox(listBoxSelectedChats, SettingsManager.Instance.Settings.SubscribedChats);
                buttonSave.Enabled = true;

            }
        }

        private void buttonRemoveChat_Click(object sender, EventArgs e)
        {
            SkypeChat selectedChat = listBoxSelectedChats.SelectedItem as SkypeChat;
            if (selectedChat != null)
            {
                SkypeChat chatToRemove = SettingsManager.Instance.Settings.SubscribedChats.Find(chat => chat.ID == selectedChat.ID);
                if (chatToRemove != null)
                {
                    SettingsManager.Instance.Settings.SubscribedChats.Remove(chatToRemove);
                }
                listBoxSelectedChats.Items.Remove(selectedChat);
                RefreshListBox(listBoxSelectedChats, SettingsManager.Instance.Settings.SubscribedChats);
                buttonSave.Enabled = true;

            }
        }

        private void buttonAddContact_Click(object sender, EventArgs e)
        {
            SkypeContact selectedContact = listBoxAllContacts.SelectedItem as SkypeContact;
            if (selectedContact != null && SettingsManager.Instance.Settings.SubscribedContacts.Find(contact => contact.ID == selectedContact.ID) == null)
            {
                SettingsManager.Instance.Settings.SubscribedContacts.Add(selectedContact);
                listBoxSelectedContacts.Items.Add(selectedContact);
                RefreshListBox(listBoxSelectedContacts, SettingsManager.Instance.Settings.SubscribedContacts);
                buttonSave.Enabled = true;

            }
        }

        private void buttonRemoveContact_Click(object sender, EventArgs e)
        {
            SkypeContact selectedContact = listBoxSelectedContacts.SelectedItem as SkypeContact;
            if (selectedContact != null)
            {
                SkypeContact contactToRemove = SettingsManager.Instance.Settings.SubscribedContacts.Find(contact => contact.ID == selectedContact.ID);
                if (contactToRemove != null)
                {
                    SettingsManager.Instance.Settings.SubscribedContacts.Remove(contactToRemove);
                }
                listBoxSelectedContacts.Items.Remove(selectedContact);
                RefreshListBox(listBoxSelectedContacts, SettingsManager.Instance.Settings.SubscribedContacts);
                buttonSave.Enabled = true;

            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            SettingsManager.Instance.Settings.Email = textBoxEmail.Text;
            buttonSave.Enabled = true;
        }

        private void textBoxInterval_TextChanged(object sender, EventArgs e)
        {
            int interval = 10;
            if (int.TryParse(textBoxInterval.Text, out interval))
            {
                SettingsManager.Instance.Settings.Timer = interval;
                buttonSave.Enabled = true;
            }
            
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canCancel)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private bool canCancel = false;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canCancel = true;
            Close();
        }

    }
}
