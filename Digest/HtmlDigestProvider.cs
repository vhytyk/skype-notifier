using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkypeNotifier.Digest
{
    public class HtmlDigestProvider : IDigestProvider
    {
        public string CreateDigest(List<SkypeChat> chats, List<SkypeContact> contacts)
        {
            StringBuilder digest = new StringBuilder();

            bool needToAddHeader = true;

            chats.ForEach(chat =>
            {
                List<SkypeMessage> messages = SkypeNotifier.Instance.GetMessagesFromChat(chat);
                if (messages.Count > 0)
                {
                    if (needToAddHeader)
                    {
                        digest.AppendLine("<h2>Chats:</h2>");
                        digest.AppendLine("<hr/>");
                        needToAddHeader = false;
                    }

                    SkypeNotifier.Instance.Settings.LastChatIds[chat.ID] = messages.Last().ID;
                    digest.AppendLine(string.Format("<h3>{0}:</h3>", chat.DisplayName));
                    messages.ForEach(message => digest.AppendLine(string.Format("{0}<br />", message.ToString())));
                    digest.AppendLine("<br />");
                }
            });

            needToAddHeader = true;

            contacts.ForEach(contact => 
            {
                List<SkypeMessage> messages = SkypeNotifier.Instance.GetMessagesFromContact(contact);
                if (messages.Count > 0)
                {
                    if (needToAddHeader)
                    {
                        digest.AppendLine("<h2>Contacts:</h2>");
                        digest.AppendLine("<hr/>");
                        needToAddHeader = false;
                    }
                    SkypeNotifier.Instance.Settings.LastContactIds[contact.ID] = messages.Last().ID;
                    digest.AppendLine(string.Format("<h3>{0}:</h3>", contact.DisplayName));
                    messages.ForEach(message => digest.AppendLine(string.Format("{0}<br />", message.ToString())));
                    digest.AppendLine("<br />");
                }
            });

            return digest.ToString();
        }
    }
}
