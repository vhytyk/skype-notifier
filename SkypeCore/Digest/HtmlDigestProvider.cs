using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            DigestFilter filter = _filterFunction != null ? _filterFunction() : null;
            DigestResult<string> result = new DigestResult<string>() { LastGeneratedChatIds = new SerializableDictionary<long, long>(), LastGeneratedContactIds = new SerializableDictionary<long, long>()};
            bool needToAddHeader = true;

            chats.ForEach(chat =>
            {
                long lastChatId = (null != filter && null != filter.StartChatIds && filter.StartChatIds.ContainsKey(chat.ID)) ? filter.StartChatIds[chat.ID] : -1;
                List<SkypeMessage> messages = _dal.GetAllMessages(lastChatId, chat).OrderBy(message => message.Time).ToList();
                if (messages.Count > 0)
                {
                    if (needToAddHeader)
                    {
                        digest.AppendLine("<h2>Chats:</h2>");
                        digest.AppendLine("<hr/>");
                        needToAddHeader = false;
                    }

                    result.LastGeneratedChatIds[chat.ID] = messages.Last().ID;
                    digest.AppendLine(string.Format("<h3>{0}:</h3>", chat.DisplayName));
                    messages.ForEach(message => digest.AppendLine(string.Format("{0}<br />", message.ToString())));
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
                    if (needToAddHeader)
                    {
                        digest.AppendLine("<h2>Contacts:</h2>");
                        digest.AppendLine("<hr/>");
                        needToAddHeader = false;
                    }
                    result.LastGeneratedContactIds[contact.ID] = messages.Last().ID;
                    digest.AppendLine(string.Format("<h3>{0}:</h3>", contact.DisplayName));
                    messages.ForEach(message => digest.AppendLine(string.Format("{0}<br />", message.ToString())));
                    digest.AppendLine("<br />");
                }
            });

            result.Result = digest.ToString();

            if (_resultAction != null)
            {
                _resultAction(result);
            }

            return result;
        }
    }
}
