using System;
using System.Collections.Generic;
using proto.mail;
using UnityEngine;

public class MailHandler : IMsgHandler
{
    public void RegisterMsg(Dictionary<MsgID, Action<SocketModel>> handlers)
    {
        handlers.Add(MsgID.MailInfos_SRES, OnMailInfos);
        handlers.Add(MsgID.Send_SRES, OnSendMail);
        handlers.Add(MsgID.Delete_Mail_SRES, OnDeleteMail);
        handlers.Add(MsgID.RecvItem_SRES, OnRecvItem);
    }

    private void OnMailInfos(SocketModel model)
    {
        //RespMailInfos resp = SerializeUtil.Deserialize<RespMailInfos>();
        RespMailInfos resp = SerializeUtil.Deserialize<RespMailInfos>(model.message);

        WindowManager.instance.Open<MailWnd>().Initialize(resp.mails);
    }

    private void OnSendMail(SocketModel model)
    {
        RespSendMail resp = SerializeUtil.Deserialize<RespSendMail>(model.message);
        Debug.Log(resp.msgtips);
        if (resp.msgtips == (int)MsgTips.SendMailSuccess)
        {
            WindowManager.instance.Close<SendWnd>();
            DataCache.instance.currentCharacter.gold -= resp.goldReceived;      
            MessageBox.Show("发送成功");
        }
        else if (resp.msgtips == (int)MsgTips.SendGoldNotEnough)
        {
            MessageBox.Show("金币不足");
        }
        else if (resp.msgtips == (int)MsgTips.SendMailFail)
        {
            MessageBox.Show("账号不存在");
        }
    }

    private void OnDeleteMail(SocketModel model)
    {
        RespDeleteMail resp = SerializeUtil.Deserialize<RespDeleteMail>(model.message);
        if(resp.msgtips == (int)MsgTips.DeleteMailSuccess)
        {
            WindowManager.instance.Close<MailContentWnd>();
            WindowManager.instance.Get<MailWnd>().Delete(resp.mailid);
        }
    }

    private void OnRecvItem(SocketModel model)
    {

    }
}

