using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reids_sentinel
{
    /// <summary>
    /// Redis哨兵模式，通过哨兵来获取master节点的连接
    /// </summary>
    public class UseRedis
    {
        /// <summary>
        /// 可用的master节点
        /// </summary>
        private readonly ConnectionMultiplexer _cli;


        public UseRedis()
        {

            if (_cli == null)
            {
                _cli = Init();
            }

        }

        /// <summary>
        /// 哨兵那获取一个可用的Master连接
        /// </summary>
        /// <returns></returns>
        private ConnectionMultiplexer Init()
        {
            #region 哨兵配置项


            ConfigurationOptions sentineOptions = new ConfigurationOptions();
            sentineOptions.Proxy = Proxy.Twemproxy;//标识正在使用代理
            sentineOptions.ServiceName = "ilbli";//服务名称

            //哨兵节点配置（可以配置多个）
            sentineOptions.EndPoints.Add("");

            #endregion

            //连接哨兵
            ConnectionMultiplexer sentineCli = ConnectionMultiplexer.SentinelConnect(sentineOptions);

            #region Master节点配置


            ConfigurationOptions serviceOptions = new ConfigurationOptions();
            serviceOptions.ClientName = "master_ilbli";
            serviceOptions.AbortOnConnectFail = true;
            #endregion
            //从哨兵那获取一个可用的Master连接
            ConnectionMultiplexer _cli = sentineCli.GetSentinelMasterConnection(serviceOptions);

            return _cli;
        }

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <returns></returns>
        public IDatabase GetDatabase()
        {
            return _cli.GetDatabase();
        }
    }
}
