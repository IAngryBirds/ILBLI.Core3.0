using System;
using System.Threading.Tasks;

namespace Reids_sentinel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //UseRedis useRedis = new UseRedis();

            string key = "ILBLI:Sentinel:CS:001";

            var txt = string.Empty;

            Task.Run(() =>
            {
                while(true)
                {
                    if (string.IsNullOrWhiteSpace(txt))
                        txt = Console.ReadLine(); 
                }

            });

          

            Task.Run(()=>
            {

                while (true)
                {
                    if (!string.IsNullOrWhiteSpace(txt))
                    {
                        Console.WriteLine($"这是输出内容：{txt}");
                        txt = string.Empty;
                        //useRedis.GetDatabase().StringSet(key, "测试的数据");
                    } 
                }

            });

            while (true)
            {

            }
        }

  
    }
}
