using System;
using System.Collections.Generic;
using System.Threading;
using log4net;
using log4net.Config;
using System.Reflection;
using System.IO;

public class GameServer
{
    public GameServer()
    {

        XmlConfigurator.Configure();
        Type type = MethodBase.GetCurrentMethod().DeclaringType;
        ILog m_log = LogManager.GetLogger(type);

        m_log.Debug("这是一个Debug日志");
        m_log.Info("这是一个Info日志");
        m_log.Warn("这是一个Warn日志");
        m_log.Error("这是一个Error日志");
        m_log.Fatal("这是一个Fatal日志");


        // 载入配置文件
        ConfigManager.instance.Initialize(new ConfigParser());
        
        // 连接到数据库
        MysqlManager.instance.Connect();

        // 服务器初始化
        NetworkManager ss = new NetworkManager(9000, new HandlerCenter());
        ss.Start(6650);


        while (true)
        {
            Thread.Sleep(10);
        }
    }
}