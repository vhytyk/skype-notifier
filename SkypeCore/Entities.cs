using System;

namespace SkypeCore
{
    public class SkypeContact
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", DisplayName);
        }
    }
    public class SkypeChat
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string DialogPartner { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", DisplayName);
        }
    }

    public enum MessageType {Message = 61, LeaveTheChat = 13, EnterTheChat = 10}

    public class SkypeMessage
    {
        public long ID { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public string PointedPerson { get; set; }
        public DateTime Time { get; set; }
        public MessageType Type;
        public SkypeChat Chat { get; set; }

        public void HandleMessageType()
        {
            switch (Type)
            {
                case MessageType.EnterTheChat:
                    Message = string.Format(" *** added {0}", PointedPerson);
                    break;
                case  MessageType.LeaveTheChat:
                    Message = " has left";
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}: {2}",Time, Author, Message);
        }
    }
}
