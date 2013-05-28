using System.Collections.Generic;
using SkypeCore.Digest;
namespace SkypeCore.DigestAction
{
    public interface IDigestActionProvider<T>
    {
        bool Execute(IDigestProvider<T> provider, List<SkypeChat> chats, List<SkypeContact> contacts);
    }
}
