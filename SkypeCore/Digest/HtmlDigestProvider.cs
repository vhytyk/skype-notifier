using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkypeCore.MessagesFormatter;

namespace SkypeCore.Digest
{
    public class HtmlDigestProvider : IDigestProvider<string>
    {
        private readonly SkypeDAL _dal = new SkypeDAL();
        private Func<DigestFilter> _filterFunction;
        private Action<DigestResult<string>> _resultAction;

        public void Initialize(Func<DigestFilter> filterFunction, Action<DigestResult<string>> resultAction)
        {
            _filterFunction = filterFunction;
            _resultAction = resultAction;
        }

        public DigestResult<string> GenerateDigest(List<SkypeChat> chats, List<SkypeContact> contacts)
        {
            StringBuilder digest = new StringBuilder();
            
            digest.Append("<html>");

            DigestFilter filter = _filterFunction != null ? _filterFunction() : null;
            DigestResult<string> result = new DigestResult<string>() { LastGeneratedChatIds = new SerializableDictionary<long, long>(), LastGeneratedContactIds = new SerializableDictionary<long, long>()};
            
            bool needToAddHeader = true;
            bool hasMessages = false;
            IMessagesFormatter messagesFormatter = new HtmlMessagesFormatter(css => digest.AppendFormat("<head><style>{0}</style></head><body>", css));

            chats.ForEach(chat =>
            {
                long lastChatId = (null != filter && null != filter.StartChatIds && filter.StartChatIds.ContainsKey(chat.ID)) ? filter.StartChatIds[chat.ID] : -1;
                List<SkypeMessage> messages = _dal.GetAllMessages(lastChatId, chat).OrderBy(message => message.Time).ToList();
                if (messages.Count > 0)
                {
                    hasMessages = true;
                    if (needToAddHeader)
                    {
                        digest.AppendLine("<h2>Chats:</h2>");
                        digest.AppendLine("<hr/>");
                        needToAddHeader = false;
                    }

                    result.LastGeneratedChatIds[chat.ID] = messages.Last().ID;
                    digest.AppendLine(string.Format("<h3>{0}:</h3>", chat.DisplayName));
                    digest.Append(messagesFormatter.FormatMessages(messages));
                    digest.AppendLine("<br />");
                }
            });

            needToAddHeader = true;

            contacts.ForEach(contact =>
            {
                long lastContactId = (null != filter && null != filter.StartContactIds && filter.StartContactIds.ContainsKey(contact.ID)) ? filter.StartContactIds[contact.ID] : -1;
                List<SkypeMessage> messages = _dal.GetAllMessages(lastContactId, contact).OrderBy(message => message.Time).ToList();
                if (messages.Count > 0)
                {
                    hasMessages = true;
                    if (needToAddHeader)
                    {
                        digest.AppendLine("<h2>Contacts:</h2>");
                        digest.AppendLine("<hr/>");
                        needToAddHeader = false;
                    }
                    result.LastGeneratedContactIds[contact.ID] = messages.Last().ID;
                    digest.AppendLine(string.Format("<h3>{0}:</h3>", contact.DisplayName));
                    digest.Append(messagesFormatter.FormatMessages(messages));
                    digest.AppendLine("<br />");
                }
            });

            digest.Append("</body></html>");
            if (hasMessages)
            {
                result.Result = digest.ToString();

                if (_resultAction != null)
                {
                    _resultAction(result);
                }
            }

            return result;
        }
    }
}
