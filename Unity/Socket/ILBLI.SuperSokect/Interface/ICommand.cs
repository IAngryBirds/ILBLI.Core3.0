using SuperSocket;
using SuperSocket.ProtoBase;
using System.Threading.Tasks;

namespace ILBLI.SuperSokect
{
    public interface ICommand<TKey>
    {
        TKey Key { get; }

        string Name { get; }
    }

    // Sync Command
    public interface ICommand<TKey, TPackageInfo> : ICommand<TKey>
        where TPackageInfo : IKeyedPackageInfo<TKey>
    {
        void Execute(IAppSession session, TPackageInfo package);
    }

    // Async Command
    public interface IAsyncCommand<TKey, TPackageInfo> : ICommand<TKey>
        where TPackageInfo : IKeyedPackageInfo<TKey>
    {
        Task ExecuteAsync(IAppSession session, TPackageInfo package);
    }
}
