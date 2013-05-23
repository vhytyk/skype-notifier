using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkypeNotifier.Action;
using SkypeNotifier.Digest;

namespace SkypeNotifier.DigestAction
{
    public class MailActionProvider : IDigestActionProvider
    {
        public bool Execute(IDigestProvider provider)
        {
            string digest = provider.CreateDigest(SkypeNotifier.Instance.Settings.SubscribedChats, SkypeNotifier.Instance.Settings.SubscribedContacts);
            SkypeNotifier.Instance.SaveSettings();
            if (!string.IsNullOrWhiteSpace(digest))
            {
                try
                {
                    MailSender.SendEmail(SkypeNotifier.Instance.Settings.Email, digest);
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
