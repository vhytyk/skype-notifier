using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using SkypeCore;
using SkypeCore.Digest;
using SkypeCore.DigestAction;

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
            SkypeDAL.ConnectionString = string.Format(@"Data Source={0};Version=3;", Settings.DbPath);
            dal = new SkypeDAL();
            IsConnected = dal.IsConnected();
            if (IsConnected)
            {
                InitializeDigest();
                dal.GetAllContacts().OrderBy(contact => contact.DisplayName).ToList().ForEach(contact => allContacts.Add(contact.ID, contact));
                dal.GetAllChats().OrderBy(chat => chat.DisplayName).ToList().ForEach(chat => allChats.Add(chat.ID, chat));
               
            }
        }
        public void InitializeDigest()
        {
            digestProvider = new HtmlDigestProvider();

            digestProvider.Initialize(() =>
            {
                DigestFilter filter = new DigestFilter();
                filter.StartChatIds = Settings.LastChatIds;
                filter.StartContactIds = Settings.LastContactIds;
                return filter;
            },
                result =>
                {
                    result.LastGeneratedChatIds.ToList().ForEach(pair =>
                    {
                        Settings.LastChatIds[pair.Key] = pair.Value;
                    });
                    result.LastGeneratedContactIds.ToList().ForEach(pair =>
                    {
                        Settings.LastContactIds[pair.Key] = pair.Value;
                    });
                     
                    SaveSettings();
                });
            digestActionProvider = new GMailActionProvider(Settings.Email, Settings.GmailAccount, Settings.GmailPassword);
            //TODO: this is little trick how ot NOT send all data from first load (last message ids are saved after digest is created)
            digestProvider.GenerateDigest(Settings.SubscribedChats, Settings.SubscribedContacts);
        }
        #endregion

        #region fields

        private SkypeDAL dal = null;
        private Dictionary<long, SkypeContact> allContacts = new Dictionary<long, SkypeContact>();
        private Dictionary<long, SkypeChat> allChats = new Dictionary<long, SkypeChat>();
        private IDigestProvider<string> digestProvider = null;
        private IDigestActionProvider<string> digestActionProvider = null;
        #endregion

        #region timer
        private Timer timer = null;
        public void StartTimer()
        {
            timer = new Timer(state =>
            {
                if (IsConnected)
                {
                    digestActionProvider.Execute(digestProvider, Settings.SubscribedChats, Settings.SubscribedContacts);
                }

            },null,5000, Settings.Timer*1000);
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

      
        #endregion
    }
}
