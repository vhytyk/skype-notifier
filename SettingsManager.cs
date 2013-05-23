using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace SkypeNotifier
{
    public class SettingsData
    {
        public SettingsData()
        {
            SubscribedChats = new List<SkypeChat>();
            SubscribedContacts = new List<SkypeContact>();
            LastChatIds = new SerializableDictionary<long, long>();
            LastContactIds = new SerializableDictionary<long, long>();
            Timer = 10;
        }
        public string Email { get; set; }
        public int Timer { get; set; } //in seconds
        public List<SkypeChat> SubscribedChats { get; set; }
        public List<SkypeContact> SubscribedContacts { get; set; }
        public SerializableDictionary<long, long> LastChatIds { get; set; }
        public SerializableDictionary<long, long> LastContactIds { get; set; }
    }

    public class SettingsManager
    {
        #region singleton
        private static SettingsManager instance;

        private SettingsManager() { }

        public static SettingsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SettingsManager();
                    instance.Init();
                }
                return instance;
            }
        }
        #endregion

        Dictionary<long, SkypeContact> allContacts = new Dictionary<long, SkypeContact>();
        Dictionary<long, SkypeChat> allChats = new Dictionary<long, SkypeChat>();
      
        DAL dal = new DAL();

        void Init()
        {
            dal.GetAllContacts().OrderBy(contact => contact.DisplayName).ToList().ForEach(contact => allContacts.Add(contact.ID, contact));
            dal.GetAllChats().OrderBy(chat => chat.DisplayName).ToList().ForEach(chat => allChats.Add(chat.ID, chat));
            LoadSettings();
            CreateDigest(true);
        }
        
        private Timer timer = null;
        public void StartTimer()
        {
            timer = new Timer(state =>
            {
                string digest = CreateDigest();

                if (!string.IsNullOrWhiteSpace(digest))
                {
                    MailSender.SendEmail(Settings.Email, digest);
                }

            },null,1000, Settings.Timer*1000);
        }
        public void StopTimer()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
        }

        private const string settingsFile = "settings.xml";
        public SettingsData Settings { get; set; }

        public void SaveSettings()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SettingsData));
                using (StreamWriter writer = new StreamWriter(settingsFile))
                {
                    serializer.Serialize(writer, Settings);
                }
            }
            catch
            {
                
            }
        }

        public void LoadSettings()
        {
            this.Settings = new SettingsData();
            try
            {
                if (File.Exists(settingsFile))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SettingsData));
                    using (StreamReader reader = new StreamReader(settingsFile))
                    {
                        this.Settings = serializer.Deserialize(reader) as SettingsData;
                    }
                }
            }
            catch
            {
               
            }
            
        }

        public List<SkypeChat> GetAllChats()
        {
            return allChats.Select(pair => pair.Value).ToList();
        }
        public List<SkypeContact> GetAllContacts()
        {
            return allContacts.Select(pair => pair.Value).ToList();
        }

        public SkypeChat GetChatById(long id)
        {
            return (allChats.ContainsKey(id)) ? allChats[id] : new SkypeChat() {DisplayName = "<Undefined chat>"};
        }
        public SkypeContact GetContactById(long id)
        {
            return (allContacts.ContainsKey(id)) ? allContacts[id] : new SkypeContact() { DisplayName = "<Undefined contact>" };
        }

        public List<SkypeMessage> GetMessagesFromChat(SkypeChat chat)
        {
            long lastMessageId = Settings.LastChatIds.ContainsKey(chat.ID) ? Settings.LastChatIds[chat.ID] : -1;
            return dal.GetAllMessages(lastMessageId, chat).OrderBy(message => message.Time).ToList();
        }

        public List<SkypeMessage> GetMessagesFromContact(SkypeContact contact)
        {
            long lastMessageId = Settings.LastContactIds.ContainsKey(contact.ID) ? Settings.LastContactIds[contact.ID] : -1;
            return dal.GetAllMessages(lastMessageId, contact).OrderBy(message => message.Time).ToList();
        }

        public string CreateDigest(bool doNotGenerate = false)
        {
            StringBuilder digest = new StringBuilder();

            bool needToAddHeader = true;

            Settings.SubscribedChats.ForEach(chat =>
            {
                List<SkypeMessage> messages = GetMessagesFromChat(chat);
                if (messages.Count > 0)
                {
                    if (needToAddHeader)
                    {
                        digest.AppendLine("<h2>Chats:</h2>");
                        digest.AppendLine("<hr/>");
                        needToAddHeader = false;
                    }

                    Settings.LastChatIds[chat.ID] = messages.Last().ID;
                    if (!doNotGenerate)
                    {
                        digest.AppendLine(string.Format("<h3>{0}:</h3>", chat.DisplayName));
                        messages.ForEach(message => digest.AppendLine(string.Format("{0}<br />", message.ToString())));
                        digest.AppendLine("<br />");
                    }
                }
            });

            needToAddHeader = true;
            
            Settings.SubscribedContacts.ForEach(contact =>
            {
                List<SkypeMessage> messages = GetMessagesFromContact(contact);
                if (messages.Count > 0)
                {
                    if (needToAddHeader)
                    {
                        digest.AppendLine("<h2>Contacts:</h2>");
                        digest.AppendLine("<hr/>");
                        needToAddHeader = false;
                    }
                    Settings.LastContactIds[contact.ID] = messages.Last().ID;
                    if (!doNotGenerate)
                    {
                        digest.AppendLine(string.Format("<h3>{0}:</h3>", contact.DisplayName));
                        messages.ForEach(message => digest.AppendLine(string.Format("{0}<br />", message.ToString())));
                        digest.AppendLine("<br />");
                    }
                }
            });
            
            SaveSettings();

            return digest.ToString();
        }
    }
}
