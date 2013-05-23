using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using SkypeNotifier.Digest;

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
        void Init()
        {
            dal.GetAllContacts().OrderBy(contact => contact.DisplayName).ToList().ForEach(contact => allContacts.Add(contact.ID, contact));
            dal.GetAllChats().OrderBy(chat => chat.DisplayName).ToList().ForEach(chat => allChats.Add(chat.ID, chat));
            LoadSettings();
            //TODO: this is little trick how ot NOT send all data from first load (last message ids are saved after digest is created)
            digestProvider.CreateDigest(Settings.SubscribedChats, Settings.SubscribedContacts);
            SaveSettings();
        }
        #endregion

        #region fields
        Dictionary<long, SkypeContact> allContacts = new Dictionary<long, SkypeContact>();
        Dictionary<long, SkypeChat> allChats = new Dictionary<long, SkypeChat>();
      
        DAL dal = new DAL();

        IDigestProvider digestProvider = new HtmlDigestProvider(); //TODO: choose provider from list
        #endregion

        #region timer
        private Timer timer = null;
        public void StartTimer()
        {
            timer = new Timer(state =>
            {
                string digest = digestProvider.CreateDigest(Settings.SubscribedChats, Settings.SubscribedContacts);

              

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
