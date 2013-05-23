using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using SkypeNotifier.Digest;
using SkypeNotifier.Action;
using SkypeNotifier.DigestAction;

namespace SkypeNotifier
{
    
    public class SkypeNotifier
    {
        #region singleton&init
        private static SkypeNotifier instance;

        private SkypeNotifier() { }

        public static SkypeNotifier Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SkypeNotifier();
                    instance.Init();
                }
                return instance;
            }
        }
        public void Init()
        {
            LoadSettings();
            dal = new DAL();
            IsConnected = dal.IsConnected();
            if (IsConnected)
            {
                dal.GetAllContacts().OrderBy(contact => contact.DisplayName).ToList().ForEach(contact => allContacts.Add(contact.ID, contact));
                dal.GetAllChats().OrderBy(chat => chat.DisplayName).ToList().ForEach(chat => allChats.Add(chat.ID, chat));
                //TODO: this is little trick how ot NOT send all data from first load (last message ids are saved after digest is created)
                digestProvider.CreateDigest(Settings.SubscribedChats, Settings.SubscribedContacts);
                SaveSettings();
            }
        }
        #endregion

        #region fields

        private DAL dal = null;
        Dictionary<long, SkypeContact> allContacts = new Dictionary<long, SkypeContact>();
        Dictionary<long, SkypeChat> allChats = new Dictionary<long, SkypeChat>();
        IDigestProvider digestProvider = new HtmlDigestProvider(); //TODO: choose provider from list
        IDigestActionProvider digestActionProvider   = new MailActionProvider();
        #endregion

        #region timer
        private Timer timer = null;
        public void StartTimer()
        {
            timer = new Timer(state =>
            {
                if (IsConnected)
                {
                    digestActionProvider.Execute(digestProvider);
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
        #endregion

        #region settings
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
        #endregion

        #region public methods
        public bool IsConnected { get; set; }
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

        #endregion
    }
}
