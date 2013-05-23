using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Configuration;

namespace SkypeNotifier
{
    public class DAL
    {
        private const string DBPathConfigKey = "DBPath";
        private string connectionString = string.Format(@"Data Source={0};Version=3;", ConfigurationManager.AppSettings[DBPathConfigKey]);


        #region helpers
        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        private void RunReader(string sql, Action<SQLiteDataReader> action)
        {
            
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        action(reader);
                    }
                }
            } 
        }
        #endregion

        public List<SkypeContact> GetAllContacts()
        {
            List<SkypeContact> result = new List<SkypeContact>();
            RunReader("select * from contacts", reader =>
            {
                while (reader.Read())
                {
                    object displayName = reader.GetValue(reader.GetOrdinal("displayname"));
                    object skypename = reader.GetValue(reader.GetOrdinal("skypename"));
                    result.Add(new SkypeContact()
                    {
                        ID = reader.GetInt64(reader.GetOrdinal("id")),
                        Name = (skypename == null) ? string.Empty : skypename.ToString(),
                        DisplayName = (displayName == null) ? string.Empty : displayName.ToString()
                    });
                }
            });
            return result;
        }
        public List<SkypeChat> GetAllChats()
        {
            List<SkypeChat> result = new List<SkypeChat>();
            RunReader("select * from chats", reader =>
            {
                while (reader.Read())
                {
                    object dialogPartner = reader.GetValue(reader.GetOrdinal("dialog_partner"));
                    result.Add(new SkypeChat()
                    {

                        ID = reader.GetInt64(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        DisplayName = reader.GetString(reader.GetOrdinal("friendlyname")),
                        DialogPartner = (dialogPartner == null) ? string.Empty : dialogPartner.ToString()
                    });
                }
            });
            return result;
        }
        public List<SkypeMessage> GetAllMessages(long fromId, SkypeContact contact)
        {
            List<SkypeMessage> messages = new List<SkypeMessage>();
            if (contact == null)
            {
                return messages;
            }
            GetAllChats().Where(chat => chat.DialogPartner == contact.Name).ToList().ForEach(chat =>
            {
                messages.AddRange(GetAllMessages(fromId, chat));
            });

            return messages.OrderBy(m => m.Time).ToList();
        }
        public List<SkypeMessage> GetAllMessages(long fromId, SkypeChat chat)
        {
            List<SkypeMessage> result = new List<SkypeMessage>();
            if (chat == null)
            {
                return result;
            }
            RunReader(string.Format("select * from messages where chatname = '{0}' and id>{1} order by timestamp", chat.Name, fromId),
                reader =>
                {
                    while (reader.Read())
                    {
                        long id = reader.GetInt64(reader.GetOrdinal("id"));
                        string from = reader.GetString(reader.GetOrdinal("from_dispname"));
                        int messageType = reader.GetInt32(reader.GetOrdinal("type"));
                        object identities = reader.GetValue(reader.GetOrdinal("identities"));
                        object body = reader.GetValue(reader.GetOrdinal("body_xml"));
                        long timestamp = reader.GetInt64(reader.GetOrdinal("timestamp"));
                        DateTime time = UnixTimeStampToDateTime(timestamp);
                        SkypeMessage message = new SkypeMessage
                        {
                            ID = id,
                            Author = from,
                            Message = (body == null) ? string.Empty : body.ToString(),
                            PointedPerson = (identities == null) ? string.Empty : identities.ToString(),
                            Chat = chat,
                            Time = time,
                            Type = (MessageType)messageType
                        };
                        message.HandleMessageType();
                        result.Add(message);
                    }
                });

            return result;
        }
    }
}
