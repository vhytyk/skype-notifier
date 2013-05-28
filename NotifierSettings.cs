using System.Collections.Generic;
using System.ComponentModel;
using SkypeCore;

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
            Timer = 60;
        }
        [Description("Path to Skype DB (tipically it's smth like this: ~<your_user_folder>/AppData/Roaming/Skype/<your_skype_usr_name>/main.db)")]
        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DbPath { get; set; }
        [Description("Email where notification digest will be send")]
        public string Email { get; set; }
        [Description("Gmail account from where notification digest will be send")]
        public string GmailAccount { get; set; }
        [Description("Gmail password")]
        [PasswordPropertyText(true)]
        public string GmailPassword { get; set; }
        [Description("Time of interval between sending digest (in seconds)")]
        public int Timer { get; set; } //in seconds
        [Browsable(false)]
        public List<SkypeChat> SubscribedChats { get; set; }
        [Browsable(false)]
        public List<SkypeContact> SubscribedContacts { get; set; }
        [Browsable(false)]
        public SerializableDictionary<long, long> LastChatIds { get; set; }
        [Browsable(false)]
        public SerializableDictionary<long, long> LastContactIds { get; set; }
    }

}
