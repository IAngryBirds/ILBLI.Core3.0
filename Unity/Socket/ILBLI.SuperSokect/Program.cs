using Microsoft.Extensions.Hosting;
using SuperSocket;
using SuperSocket.ProtoBase;
using System;
using System.Linq;
using System.Text;

namespace ILBLI.SuperSokect
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //用Package的类型和PipeLineFilter的类型创建SuperSocket宿主。
            var host = SuperSocketHostBuilder.Create<StringPackageInfo, CommandLinePipelineFilter>()

                           .ConfigurePackageHandler(async (s, p) =>
                           {
                               var result = 0;

                               switch (p.Key.ToUpper())
                               {
                                   case ("ADD"):
                                       result = p.Parameters
                                           .Select(p => int.Parse(p))
                                           .Sum();
                                       break;

                                   case ("SUB"):
                                       result = p.Parameters
                                           .Select(p => int.Parse(p))
                                           .Aggregate((x, y) => x - y);
                                       break;

                                   case ("MULT"):
                                       result = p.Parameters
                                           .Select(p => int.Parse(p))
                                           .Aggregate((x, y) => x * y);
                                       break;
                               }

                               await s.SendAsync(Encoding.UTF8.GetBytes(result.ToString() + "\r\n"));
                           })
                           .ConfigureLogging((hostCtx, loggingBuilder) =>
                           {
                               loggingBuilder.Services();
                           })
                           .ConfigureSuperSocket(options =>
                           {
                               options.Name = "Echo Server";
                               options.Listeners = new[] {
                                    new ListenOptions
                                    {
                                        Ip = "Any",
                                        Port = 4040
                                    }
                                };
                           }).Build()
                           ;

            host.Run();
        }
    }
}
