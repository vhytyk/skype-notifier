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
            RefreshListBox(listBoxAllChats, SkypeNotifier.Instance.GetAllChats());
            RefreshListBox(listBoxSelectedChats, SkypeNotifier.Instance.Settings.SubscribedChats);
            RefreshListBox(listBoxAllContacts, SkypeNotifier.Instance.GetAllContacts());
            RefreshListBox(listBoxSelectedContacts, SkypeNotifier.Instance.Settings.SubscribedContacts);
            textBoxEmail.Text = SkypeNotifier.Instance.Settings.Email;
            textBoxInterval.Text = SkypeNotifier.Instance.Settings.Timer.ToString();
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
            SkypeNotifier.Instance.SaveSettings();
            buttonSave.Enabled = false;
        }

        private void buttonAddChat_Click(object sender, EventArgs e)
        {
            SkypeChat selectedChat = listBoxAllChats.SelectedItem as SkypeChat;
            if (selectedChat != null && SkypeNotifier.Instance.Settings.SubscribedChats.Find(chat => chat.ID == selectedChat.ID) == null)
            {
                SkypeNotifier.Instance.Settings.SubscribedChats.Add(selectedChat);
                listBoxSelectedChats.Items.Add(selectedChat);
                RefreshListBox(listBoxSelectedChats, SkypeNotifier.Instance.Settings.SubscribedChats);
                buttonSave.Enabled = true;

            }
        }

        private void buttonRemoveChat_Click(object sender, EventArgs e)
        {
            SkypeChat selectedChat = listBoxSelectedChats.SelectedItem as SkypeChat;
            if (selectedChat != null)
            {
                SkypeChat chatToRemove = SkypeNotifier.Instance.Settings.SubscribedChats.Find(chat => chat.ID == selectedChat.ID);
                if (chatToRemove != null)
                {
                    SkypeNotifier.Instance.Settings.SubscribedChats.Remove(chatToRemove);
                }
                listBoxSelectedChats.Items.Remove(selectedChat);
                RefreshListBox(listBoxSelectedChats, SkypeNotifier.Instance.Settings.SubscribedChats);
                buttonSave.Enabled = true;

            }
        }

        private void buttonAddContact_Click(object sender, EventArgs e)
        {
            SkypeContact selectedContact = listBoxAllContacts.SelectedItem as SkypeContact;
            if (selectedContact != null && SkypeNotifier.Instance.Settings.SubscribedContacts.Find(contact => contact.ID == selectedContact.ID) == null)
            {
                SkypeNotifier.Instance.Settings.SubscribedContacts.Add(selectedContact);
                listBoxSelectedContacts.Items.Add(selectedContact);
                RefreshListBox(listBoxSelectedContacts, SkypeNotifier.Instance.Settings.SubscribedContacts);
                buttonSave.Enabled = true;

            }
        }

        private void buttonRemoveContact_Click(object sender, EventArgs e)
        {
            SkypeContact selectedContact = listBoxSelectedContacts.SelectedItem as SkypeContact;
            if (selectedContact != null)
            {
                SkypeContact contactToRemove = SkypeNotifier.Instance.Settings.SubscribedContacts.Find(contact => contact.ID == selectedContact.ID);
                if (contactToRemove != null)
                {
                    SkypeNotifier.Instance.Settings.SubscribedContacts.Remove(contactToRemove);
                }
                listBoxSelectedContacts.Items.Remove(selectedContact);
                RefreshListBox(listBoxSelectedContacts, SkypeNotifier.Instance.Settings.SubscribedContacts);
                buttonSave.Enabled = true;

            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            SkypeNotifier.Instance.Settings.Email = textBoxEmail.Text;
            buttonSave.Enabled = true;
        }

        private void textBoxInterval_TextChanged(object sender, EventArgs e)
        {
            int interval = 10;
            if (int.TryParse(textBoxInterval.Text, out interval))
            {
                SkypeNotifier.Instance.Settings.Timer = interval;
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
