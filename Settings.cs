using System;
using System.Collections;
using System.Windows.Forms;
using System.Linq;
using SkypeCore;

namespace SkypeNotifier
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            Init();
            settingsGrid.SelectedObject = SkypeNotifier.Instance.Settings;

        }
        void Init()
        {
            if (SkypeNotifier.Instance.IsConnected)
            {
                RefreshListBox(listBoxAllChats, SkypeNotifier.Instance.GetAllChats());
                RefreshListBox(listBoxSelectedChats, SkypeNotifier.Instance.Settings.SubscribedChats);
                RefreshListBox(listBoxAllContacts, SkypeNotifier.Instance.GetAllContacts());
                RefreshListBox(listBoxSelectedContacts, SkypeNotifier.Instance.Settings.SubscribedContacts);
            }
            
        }
        private void RefreshListBox(ListBox listBox, IEnumerable collection)
        {
            listBox.Items.Clear();
            foreach (var item in collection)
            {
                listBox.Items.Add(item);
            }
        }

        #region event handlers
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SkypeNotifier.Instance.StopTimer();
            SkypeNotifier.Instance.SaveSettings();
            SkypeNotifier.Instance.InitializeDigest();
            SkypeNotifier.Instance.StartTimer();
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

        private bool canCancel = false;
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canCancel)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canCancel = true;
            Close();
        }

        private void settingsGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            buttonSave.Enabled = true;
            if (e.ChangedItem.PropertyDescriptor.Name == "DbPath")
            {
                SkypeNotifier.Instance.SaveSettings();
                SkypeNotifier.Instance.Init();
                Init();
            }
            if (e.ChangedItem.PropertyDescriptor.Name == "Timer")
            {
                SkypeNotifier.Instance.StopTimer();
                SkypeNotifier.Instance.StartTimer();
            }
        }
        #endregion

        private void textBoxFilterChats_KeyUp(object sender, KeyEventArgs e)
        {
            RefreshListBox(listBoxAllChats, SkypeNotifier.Instance.GetAllChats().Where(chat => chat.DisplayName.ToLower().Contains(textBoxFilterChats.Text.ToLower())));
        }

        private void textBoxFilterContact_KeyUp(object sender, KeyEventArgs e)
        {
            RefreshListBox(listBoxAllContacts, SkypeNotifier.Instance.GetAllContacts().Where(contact => contact.DisplayName.ToLower().Contains(textBoxFilterContact.Text.ToLower())));
        }


    }
}
