using System;
using System.Collections.Generic;
namespace SkypeCore.Digest
{
    public class DigestFilter
    {
        public Dictionary<long, long> StartChatIds { get; set; }
        public Dictionary<long, long> StartContactIds { get; set; }
    }
    public class DigestResult<T>
    {
        public T Result { get; set; }
        public SerializableDictionary<long, long> LastGeneratedChatIds { get; set; }
        public SerializableDictionary<long, long> LastGeneratedContactIds { get; set; }
    }
    public interface IDigestProvider<T>
    {
        void Initialize(Func<DigestFilter> filterFunction, Action<DigestResult<T>> resultAction);
        DigestResult<T> GenerateDigest(List<SkypeChat> chats, List<SkypeContact> contacts);
    }
}
