using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SkypeCore.MessagesFormatter;

namespace SkypeCore
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void HTMLMessagesFormatterTest()
        {
            //HtmlMessagesFormatter formatter = new HtmlMessagesFormatter(null);
            //List<SkypeMessage> messages = new List<SkypeMessage>(new[]
            //{
            //    new SkypeMessage()
            //    {
            //        Message = "test'test",
            //        Author = "test"
            //    }
            //});

            //Console.WriteLine(formatter.FormatMessages(messages));
            SkypeDAL dal = new SkypeDAL();
            SkypeDAL.ConnectionString = @"Data Source=C:\Users\user\AppData\Roaming\Skype\victor.hytyk.prl\main.db;Version=3;";
            SkypeContact nauroskype = dal.GetAllContacts().Find(contact => contact.Name.Contains("nauroskype"));
            HtmlMessagesFormatter formatter = new HtmlMessagesFormatter(null);
            string f = formatter.FormatMessages(new List<SkypeMessage>(new [] {dal.GetAllMessages(-1, nauroskype).Last()}));
            Console.WriteLine(f);
        }
    }
}
