using SuperSocket;
using SuperSocket.ProtoBase;
using SuperSocket.Server;
using System.Linq;
using System.Threading.Tasks;

namespace ILBLI.SuperSokect
{ 

    public class CS : IAsyncCommand<string, StringPackageInfo>
    {
        public string Key => "ADD";

        public string Name => Key;

        public async Task ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            var result = package.Parameters
                .Select(p => int.Parse(p))
                .Sum();

            await session.SendAsync(result.ToString());
        }
    }
}
