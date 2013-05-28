using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkypeCore.Digest;

namespace SkypeCore.DigestAction
{
    public class GMailActionProvider : IDigestActionProvider<string>
    {
        private readonly string _emailToSend;
        private readonly string _gmailAccount;
        private readonly string _gmailPassword;

        public GMailActionProvider(string emailToSend, string gmailAccount, string gmailPassword)
        {
            _emailToSend = emailToSend;
            _gmailAccount = gmailAccount;
            _gmailPassword = gmailPassword;
        }

        public bool Execute(IDigestProvider<string> provider, List<SkypeChat> chats, List<SkypeContact> contacts)
        {
            DigestResult<string> digest = provider.GenerateDigest(chats, contacts);
            if (!string.IsNullOrWhiteSpace(digest.Result))
            {
                try
                {
                    GMailSender.SendEmail(_emailToSend, digest.Result, _gmailAccount, _gmailPassword);
                    return true;
                }
                catch
                {
                }
            }
            return false;
        }
    }
}
