using System;
using System.Collections.Generic;
using proto.mail;
using common;
public class MailHandler : IMsgHandler
{
    public void RegisterMsg(Dictionary<MsgID, Action<UserToken, SocketModel>> handlers)
    {
        handlers.Add(MsgID.MailInfos_CREQ, OnMailInfos);
        handlers.Add(MsgID.Delete_Mail_CREQ, OnDeleteMail);
        handlers.Add(MsgID.Send_CREQ, OnSendMail);
        handlers.Add(MsgID.RecvItem_CREQ, OnRecvItem);
    }
    private void OnMailInfos(UserToken token, SocketModel model)
    {
        //List<MailData> mails = CacheManager.instance.GetPlayerData(token.characterid).mails;

        List<MailData> mails = CacheManager.instance.GetMailDatas(token.characterid);

        RespMailInfos resp = new RespMailInfos();

        foreach (MailData d in mails)
        {
            MailDTO dto = MailData.GetMailDTO(d);
            resp.mails.Add(dto);
        }

        NetworkManager.Send(token, (int)MsgID.MailInfos_SRES, resp);
    }
    private void OnDeleteMail(UserToken token, SocketModel model)
    {
        ReqDeleteMail req = SerializeUtil.Deserialize<ReqDeleteMail>(model.message);

        CacheManager.instance.DeleteMail(token.characterid, req.mailid);

        RespDeleteMail resp = new RespDeleteMail();
        resp.mailid = req.mailid;
        resp.msgtips = (int)MsgTips.DeleteMailSuccess;
        NetworkManager.Send(token, (int)MsgID.Delete_Mail_SRES, resp);
    }
    private void OnSendMail(UserToken token, SocketModel model)
    {
        ReqSendMail req = SerializeUtil.Deserialize<ReqSendMail>(model.message);
        MailDTO mailDto = req.dto;
        MailData mm = new MailData();
        mm.body = mailDto.body;
        mm.deliver_time = mailDto.deliver_time;
        mm.has_items = mailDto.has_items;
        mm.money = mailDto.money;
        mm.receiver_id = mailDto.receiver_id;
        mm.subject = mailDto.subject;
        mm.sender_id = token.characterid;
        Console.WriteLine(mailDto.body);
        RespSendMail rsp = new RespSendMail();
        CharacterData ch = CacheManager.instance.GetCharData(token.characterid);
        // if (ch != null)
        //{
        if (ch.gold < req.dto.money)
        {
            rsp.msgtips = (int)MsgTips.SendGoldNotEnough;
        }
        else
        {
            rsp.msgtips = (int)MsgTips.SendMailSuccess;
            bool isOn = CacheManager.instance.IsCharOnline(mm.receiver_id);
            if (isOn)
            {
                ch.gold -= req.dto.money;
                List<MailData> mails = CacheManager.instance.GetMailDatas(mm.receiver_id);
                mails.Add(mm);
                rsp.goldReceived = mm.money;
            }
            else
            {
                ch.gold -= req.dto.money;
                CacheManager.instance.SendMail(mm.receiver_id, mm);
                rsp.goldReceived = mm.money;
            }
        }
        NetworkManager.Send(token, (int)MsgID.Send_SRES, rsp);
        Console.WriteLine(rsp.msgtips);
    }
    private void OnRecvItem(UserToken token, SocketModel model)
    {

    }
}