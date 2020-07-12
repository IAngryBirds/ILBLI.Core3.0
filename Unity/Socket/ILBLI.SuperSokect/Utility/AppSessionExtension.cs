using SuperSocket;
using System.Text;
using System.Threading.Tasks;

namespace ILBLI.SuperSokect
{
    public static class AppSessionExtension
    {
        /// <summary>
        /// 发送消息通知
        /// </summary>
        /// <param name="session"></param>
        /// <param name="message">要发送的消息</param>
        /// <returns></returns>
        public async static Task SendAsync(this IAppSession session, string message)
        {
            var bytes = Encoding.UTF8.GetBytes($"{message} \r\n");

            await session.SendAsync(bytes); 
        }
    }
}
