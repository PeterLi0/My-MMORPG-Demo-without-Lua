using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// 消息提示
/// </summary>
public enum MsgTips
{
    NoAccount = 1001,         // 账号不存在
    AccountHasOnline = 1002,         // 账号已经在线
    PasswordError = 1003,         // 密码错误
    InputError = 1004,         // 输入不合法
    LoginSuccess = 1005,         // 登录成功

    RegisterSuccess = 1006,         // 注册成功
    AccountRepeat = 1007,         // 注册失败，账号重复
    AccountInvalid = 1008,         // 账号不合法
    PasswordInvalid = 1009,         // 密码不合法
    AccountOffline = 1010,         // 账号离线成功


    CharCreateSuccess = 1011,         // 角色创建成功
    NameRepeat = 1012,         // 角色名重复
    CharOnlineSuccess = 1013,         // 角色登录
    CharOfflineSuccess = 1014,         // 角色离线
    DeleteCharSuccess = 1015,         // 角色删除成功
    CharHasOnline = 1016,         // 角色已经在线

    EquipSuccess = 1021,         // 装备成功
    UnloadSuccess = 1022,         // 卸载成功
    DeleteItemSuccess = 1023,         // 物品删除成功

    DeleteMailSuccess = 1031,         // 邮件删除成功
    RecvItemSuccess = 1032,         // 邮件物品领取成功

    SendMailSuccess = 1033,
    SendMailFail = 1034,

    SendGoldNotEnough = 1035,

    BuyGoodsSuccess = 1041,         // 购买商品成功
    GoldNotEnough = 1042,           // 金币不足
    DiamondNotEnough = 1043,        // 钻石不足
}

