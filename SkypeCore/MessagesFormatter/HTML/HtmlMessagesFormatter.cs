using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace SkypeCore.MessagesFormatter
{
    public class SkypeEmotion
    {
        public string Name { get; set; }
        public string [] Symbols { get; set; }
        public string CssBase64Url { get; set; }
    }
    public class HtmlMessagesFormatter : IMessagesFormatter
    {
        #region emotions

        private List<SkypeEmotion> emotions = new List<SkypeEmotion>()
        {
            new SkypeEmotion {Name = "Smile", Symbols = new[] {":)", ":=)", ":-)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0100-smile.gif"},
            new SkypeEmotion {Name = "Sad Smile", Symbols = new[] {":(", ":=(", ":-("}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0101-sadsmile.gif"},
            new SkypeEmotion {Name = "Big Smile", Symbols = new[] {":D", ":=D", ":-D", ":d", ":=d", ":-d"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0102-bigsmile.gif"},
            new SkypeEmotion {Name = "Cool", Symbols = new[] {"8)", "8=)", "8-)", "B)", "B=)", "B-)", "(cool)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0103-cool.gif"},
            new SkypeEmotion {Name = "Wink", Symbols = new[] {":o", ":=o", ":-o", ":O", ":=O", ":-O"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0105-wink.gif"},
            new SkypeEmotion {Name = "Crying", Symbols = new[] {";(", ";-(", ";=("}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0106-crying.gif"},
            new SkypeEmotion {Name = "Sweating", Symbols = new[] {"(sweat)", "(:|"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0107-sweating.gif"},
            new SkypeEmotion {Name = "Speechless", Symbols = new[] {":|", ":=|", ":-|"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0108-speechless.gif"},
            new SkypeEmotion {Name = "Kiss", Symbols = new[] {":*", ":=*", ":-*"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0109-kiss.gif"},
            new SkypeEmotion {Name = "Tongue Out", Symbols = new[] {":P", ":=P", ":-P", ":p", ":=p", ":-p"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0110-tongueout.gif"},
            new SkypeEmotion {Name = "Blush", Symbols = new[] {"(blush)", ":$", ":-$", ":=$", ":\">"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0111-blush.gif"},
            new SkypeEmotion {Name = "Wondering", Symbols = new[] {":^)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0112-wondering.gif"},
            new SkypeEmotion {Name = "Sleepy", Symbols = new[] {"|-)", "I-)", "I=)", "(snooze)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0113-sleepy.gif"},
            new SkypeEmotion {Name = "Dull", Symbols = new[] {"|(", "|-(", "|=("}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0114-dull.gif"},
            new SkypeEmotion {Name = "In love", Symbols = new[] {"(inlove)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0115-inlove.gif"},
            new SkypeEmotion {Name = "Evil grin", Symbols = new[] {"]:)", ">:)", "(grin)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0116-evilgrin.gif"},
            new SkypeEmotion {Name = "Talking", Symbols = new[] {"(talk)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0117-talking.gif"},
            new SkypeEmotion {Name = "Yawn", Symbols = new[] {"(yawn)", "|-()"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0118-yawn.gif"},
            new SkypeEmotion {Name = "Puke", Symbols = new[] {"(puke)", ":&", ":-&", ":=&"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0119-puke.gif"},
            new SkypeEmotion {Name = "Doh!", Symbols = new[] {"(doh)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0120-doh.gif"},
            new SkypeEmotion
            {
                Name = "Angry",
                Symbols = new[] {":@", ":-@", ":=@", "x(", "x-(", "x=(", "X(", "X-(", "X=("},
                CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0121-angry.gif"
            },
            new SkypeEmotion {Name = "It wasn't me", Symbols = new[] {"(wasntme)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0122-itwasntme.gif"},
            new SkypeEmotion {Name = "Party!!!", Symbols = new[] {"(party)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0123-party.gif"},
            new SkypeEmotion {Name = "Worried", Symbols = new[] {":S", ":-S", ":=S", ":s", ":-s", ":=s"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0124-worried.gif"},
            new SkypeEmotion {Name = "Mmm...", Symbols = new[] {"(mm)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0125-mmm.gif"},
            new SkypeEmotion {Name = "Nerd", Symbols = new[] {"8-|", "B-|", "8|", "B|", "8=|", "B=|", "(nerd)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0126-nerd.gif"},
            new SkypeEmotion
            {
                Name = "Lips Sealed",
                Symbols = new[] {":x", ":-x", ":X", ":-X", ":#", ":-#", ":=x", ":=X", ":=#"},
                CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0127-lipssealed.gif"
            },
            new SkypeEmotion {Name = "Hi", Symbols = new[] {"(hi)","(wave)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0128-hi.gif"},
            new SkypeEmotion {Name = "Call", Symbols = new[] {"(call)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0129-call.gif"},
            new SkypeEmotion {Name = "Devil", Symbols = new[] {"(devil)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0130-devil.gif"},
            new SkypeEmotion {Name = "Angel", Symbols = new[] {"(angel)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0131-angel.gif"},
            new SkypeEmotion {Name = "Envy", Symbols = new[] {"(envy)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0132-envy.gif"},
            new SkypeEmotion {Name = "Wait", Symbols = new[] {"(wait)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0133-wait.gif"},
            new SkypeEmotion {Name = "Bear", Symbols = new[] {"(bear)", "(hug)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0134-bear.gif"},
            new SkypeEmotion {Name = "Make-up", Symbols = new[] {"(makeup)", "(kate)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0135-makeup.gif"},
            new SkypeEmotion {Name = "Covered Laugh", Symbols = new[] {"(giggle)", "(chuckle)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0136-giggle.gif"},
            new SkypeEmotion {Name = "Clapping Hands", Symbols = new[] {"(clap)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0137-clapping.gif"},
            new SkypeEmotion {Name = "Thinking", Symbols = new[] {"(think)", ":?", ":-?", ":=?"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0138-thinking.gif"},
            new SkypeEmotion {Name = "Bow", Symbols = new[] {"(bow)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0139-bow.gif"},
            new SkypeEmotion {Name = "Rolling on the floor laughing", Symbols = new[] {"(rofl)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0140-rofl.gif"},
            new SkypeEmotion {Name = "Whew", Symbols = new[] {"(whew)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0141-whew.gif"},
            new SkypeEmotion {Name = "Happy", Symbols = new[] {"(happy)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0142-happy.gif"},
            new SkypeEmotion {Name = "Smirking", Symbols = new[] {"(smirk)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0143-smirk.gif"},
            new SkypeEmotion {Name = "Nodding", Symbols = new[] {"(nod)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0144-nod.gif"},
            new SkypeEmotion {Name = "Shaking", Symbols = new[] {"(shake)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0145-shake.gif"},
            new SkypeEmotion {Name = "Punch", Symbols = new[] {"(punch)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0146-punch.gif"},
            new SkypeEmotion {Name = "Emo", Symbols = new[] {"(emo)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0147-emo.gif"},
            new SkypeEmotion {Name = "Yes", Symbols = new[] {"(y)", "(Y)", "(ok)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0148-yes.gif"},
            new SkypeEmotion {Name = "No", Symbols = new[] {"(n)", "(N)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0149-no.gif"},
            new SkypeEmotion {Name = "Shaking Hands", Symbols = new[] {"(handshake)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0150-handshake.gif"},
            new SkypeEmotion {Name = "Skype", Symbols = new[] {"(skype)", "(ss)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0151-skype.gif"},
            new SkypeEmotion {Name = "Heart", Symbols = new[] {"(h)", "(H)", "(l)", "(L)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0152-heart.gif"},
            new SkypeEmotion {Name = "Broken heart", Symbols = new[] {"(u)", "(U)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0153-brokenheart.gif"},
            new SkypeEmotion {Name = "Mail", Symbols = new[] {"(e)", "(m)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0154-mail.gif"},
            new SkypeEmotion {Name = "Flower", Symbols = new[] {"(f)", "(F)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0155-flower.gif"},
            new SkypeEmotion {Name = "Rain", Symbols = new[] {"(rain)", "(london)", "(st)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0156-rain.gif"},
            new SkypeEmotion {Name = "Sun", Symbols = new[] {"(sun)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0157-sun.gif"},
            new SkypeEmotion {Name = "Time", Symbols = new[] {"(o)", "(O)", "(time)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0158-time.gif"},
            new SkypeEmotion {Name = "Music", Symbols = new[] {"(music)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0159-music.gif"},
            new SkypeEmotion {Name = "Movie", Symbols = new[] {"(~)", "(film)", "(movie)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0160-movie.gif"},
            new SkypeEmotion {Name = "Phone", Symbols = new[] {"(mp)", "(ph)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0161-phone.gif"},
            new SkypeEmotion {Name = "Coffee", Symbols = new[] {"(coffee)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0162-coffee.gif"},
            new SkypeEmotion {Name = "Pizza", Symbols = new[] {"(pizza)", "(pi)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0163-pizza.gif"},
            new SkypeEmotion {Name = "Cash", Symbols = new[] {"(cash)", "(mo)", "($)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0164-cash.gif"},
            new SkypeEmotion {Name = "Muscle", Symbols = new[] {"(muscle)", "(flex)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0165-muscle.gif"},
            new SkypeEmotion {Name = "Cake", Symbols = new[] {"(^)", "(cake)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0166-cake.gif"},
            new SkypeEmotion {Name = "Beer", Symbols = new[] {"(beer)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0167-beer.gif"},
            new SkypeEmotion {Name = "Drink", Symbols = new[] {"(d)", "(D)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0168-drink.gif"},
            new SkypeEmotion {Name = "Dance", Symbols = new[] {"(dance)", @"\o/", @"\:D/", @"\:d/"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0169-dance.gif"},
            new SkypeEmotion {Name = "Ninja", Symbols = new[] {"(ninja)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0170-ninja.gif"},
            new SkypeEmotion {Name = "Star", Symbols = new[] {"(*)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0171-star.gif"},
            new SkypeEmotion {Name = "Mooning", Symbols = new[] {"(mooning)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0172-mooning.gif"},
            new SkypeEmotion {Name = "Finger", Symbols = new[] {"(finger)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0173-middlefinger.gif"},
            new SkypeEmotion {Name = "Bandit", Symbols = new[] {"(bandit)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0174-bandit.gif"},
            new SkypeEmotion {Name = "Drunk", Symbols = new[] {"(drunk)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0175-drunk.gif"},
            new SkypeEmotion {Name = "Smoking", Symbols = new[] {"(smoking)", "(smoke)", "(ci)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0176-smoke.gif"},
            new SkypeEmotion {Name = "Toivo", Symbols = new[] {"(toivo)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0177-toivo.gif"},
            new SkypeEmotion {Name = "Rock", Symbols = new[] {"(rock)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0178-rock.gif"},
            new SkypeEmotion {Name = "Headbang", Symbols = new[] {"(headbang)", "(banghead)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0179-headbang.gif"},
            new SkypeEmotion {Name = "Bug", Symbols = new[] {"(bug)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0180-bug.gif"},
            new SkypeEmotion {Name = "Fubar", Symbols = new[] {"(fubar)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0181-fubar.gif"},
            new SkypeEmotion {Name = "Poolparty", Symbols = new[] {"(poolparty)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0182-poolparty.gif"},
            new SkypeEmotion {Name = "Swearing", Symbols = new[] {"(swear)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0183-swear.gif"},
            new SkypeEmotion {Name = "TMI", Symbols = new[] {"(tmi)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0184-tmi.gif"},
            new SkypeEmotion {Name = "Heidy", Symbols = new[] {"(heidy)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0185-heidy.gif"},
            new SkypeEmotion {Name = "MySpace", Symbols = new[] {"(MySpace)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0186-myspace.gif"},
            new SkypeEmotion {Name = "Malthe", Symbols = new[] {"(malthe)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0187-malthe.gif"},
            new SkypeEmotion {Name = "Tauri", Symbols = new[] {"(tauri)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0188-tauri.gif"},
            new SkypeEmotion {Name = "Priidu", Symbols = new[] {"(priidu)"}, CssBase64Url = @"http://factoryjoe.s3.amazonaws.com/emoticons/emoticon-0189-priidu.gif"}


        };
        #endregion

        private readonly Action<string> _cssStyles;

        public HtmlMessagesFormatter(Action<string> cssStyles)
        {
            _cssStyles = cssStyles;
            using (StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("SkypeCore.MessagesFormatter.HTML.skypeMessages.css")))
            {
                if (null != _cssStyles)
                {
                    string css = reader.ReadToEnd();
                    _cssStyles(css);
                }
            }
        }

        public string ReplaceEmotions(string message)
        {
            string result = message;
            emotions.ForEach(emotion => emotion.Symbols.ToList().ForEach(symbol =>
            {
                result = result.Replace(symbol, string.Format("<image src='{0}' alt='{1}'/>", emotion.CssBase64Url, emotion.Name));
            }));
            return result;
        }

        public string FormatMessages(List<SkypeMessage> messages)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<table class='conversation'>");
            DateTime day = DateTime.MinValue;
            string author = string.Empty;
            messages.ForEach(message =>
            {
                DateTime messageDay = new DateTime(message.Time.Year, message.Time.Month, message.Time.Day);
                if (day != messageDay)
                {
                    result.AppendFormat("<tr><td colspan=3 class='dayHeader'>{0}</tr>", message.Time.ToLongDateString());
                    day = messageDay;
                    author = string.Empty;
                }
                if (author != message.Author)
                {
                    result.AppendFormat("<tr><td class='author' colspan=3>{0}</td></tr>", message.Author);
                    author = message.Author;
                }

                string skypeMessage = HttpUtility.HtmlEncode(message.Message).Replace("\r", "<br />");

                result.AppendFormat("<tr class='messageRow'><td class='message'>{0}</td><td class='messageTime'>{1}</td></tr>", skypeMessage, message.Time.ToShortTimeString().Replace(" ",""));
            });
            result.Append("</table>");
            return result.ToString();
        }
    }
}
