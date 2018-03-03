


public enum MsgID
{
    /// <summary>
    /// 账号协议
    /// </summary>
    ACC_LOGIN_CREQ = 1001,    // 客户端申请登录
    ACC_LOGIN_SRES = 1002,    // 服务器反馈给客户端 登录结果

    ACC_REG_CREQ = 1003,      // 客户端申请注册
    ACC_REG_SRES = 1004,      // 服务器反馈给客户端 注册结果

    ACC_OFFLINE_CREQ = 1005,   // 账号离线请求
    ACC_OFFLINE_SRES = 1006,   // 账号离线应答

    /// <summary>
    /// 角色协议
    /// </summary>

    CHAR_INFO_CREQ = 1101,     // 获取自身数据
    CHAR_INFO_SRES = 1102,     // 返回自身数据

    CHAR_CREATE_CREQ = 1103,   // 申请创建角色
    CHAR_CREATE_SRES = 1104,   // 返回创建结果

    CHAR_ONLINE_CREQ = 1105,   // 角色上线请求
    CHAR_ONLINE_SRES = 1106,   // 角色上线应答


    CHAR_OFFLINE_CREQ = 1107,  // 角色离线请求
    CHAR_OFFLINE_SRES = 1108,  // 角色离线应答

    CHAR_DELETE_CREQ = 1109,   // 删除角色请求
    CHAR_DELETE_SRES = 1110,   // 删除角色应答


    /// <summary>
    /// 场景协议
    /// </summary>

    SCENE_Char_CREQ = 1201,     // 获取场景中所有角色信息
    SCENE_Char_SRES = 1202,     // 获取场景中所有角色信息应答


    SCENE_CharOnline_NOTIFY = 1203,          // 通知角色上线
    SCENE_CharOffline_NOTIFY = 1204,         // 通知角色离线

    SCENE_CharMove_CREQ = 1205,              // 角色请求移动
    SCENE_CharMove_Notify = 1206,            // 通知角色移动



    /// <summary>
    /// 背包协议
    /// </summary>

    INV_ItemInfos_CREQ = 1301,          // 获取已有物品信息
    INV_ItemInfos_SRES = 1302,

    INV_Equip_CREQ = 1303,              // 装备物品
    INV_Equip_SRES = 1304,

    INV_Unload_CREQ = 1305,             // 卸载物品
    INV_Unload_SRES = 1306,

    INV_Delete_Item_CREQ = 1307,        // 销毁物品
    INV_Delete_Item_SRES = 1308,

    /// <summary>
    /// 邮件协议
    /// </summary>

    MailInfos_CREQ = 1401,        // 获取邮件信息
    MailInfos_SRES = 1402,

    Delete_Mail_CREQ = 1403,           // 删除邮件
    Delete_Mail_SRES = 1404,

    Send_CREQ = 1405,             // 发送邮件
    Send_SRES = 1406,

    RecvItem_CREQ = 1407,         // 领取邮件物品
    RecvItem_SRES = 1408,


    /// <summary>
    /// 任务协议
    /// </summary>

    Info_CREQ = 1501,             // 获取所有任务信息
    Info_SRES = 1502,

    Receive_CREQ = 1503,          // 接收任务
    Receive_SRES = 1504,

    Drop_CREQ = 1505,             // 放弃任务
    Drop_SRES = 1506,

    Finish_CREQ = 1507,           // 立即完成
    Finish_SRES = 1508,

    UpdateTask_CREQ = 1509,       // 更新任务状态

    /// <summary>
    /// 商城协议
    /// </summary>
    MallInfo_CREQ = 1601,       // 获取商城信息
    MallInfo_SRES = 1602,       

    BuyGoods_CREQ = 1603,       // 购买商品
    BuyGoods_SRES = 1604,
}
