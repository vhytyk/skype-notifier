using System.Collections.Generic;
namespace SkypeNotifier.Digest
{
    public interface IDigestProvider
    {
        string CreateDigest(List<SkypeChat> chats, List<SkypeContact> contacts);
    }
}
