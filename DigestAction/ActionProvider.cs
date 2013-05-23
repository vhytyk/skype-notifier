using SkypeNotifier.Digest;
namespace SkypeNotifier.Action
{
    public interface IDigestActionProvider
    {
        bool Execute(IDigestProvider provider);
    }
}
