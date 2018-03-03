using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using common;
using proto.mail;

/// <summary>
/// 邮件内容界面
/// </summary>
public class MailContentWnd : BaseWnd
{
    private MailDTO _mail;

    public void Initialize(MailDTO dto)
    {
        _mail = dto;

        Button btnClose = _transform.FindChild("BtnClose").GetComponent<Button>();
        btnClose.onClick.AddListener(OnBtnCloseClick);

        // 标题
        Text title = _transform.FindChild("Title/Text").GetComponent<Text>();
        title.text = dto.subject;

        // 内容
        Text content = _transform.FindChild("Content").GetComponent<Text>();
        content.text = dto.body;

        // 邮件物品


        // 领取物品

        // 删除邮件
        Button btnDelete = _transform.FindChild("BtnDelete").GetComponent<Button>();
        btnDelete.onClick.AddListener(OnBtnDeleteClick);
        //领取金币
        Button btnGold = _transform.FindChild("Golds").GetComponent<Button>();
        btnGold.transform.FindChild("Text").GetComponent<Text>().text = "金币："+dto.money.ToString();
        btnGold.onClick.AddListener(OnBtnGoldClick);
    }

    private void OnBtnCloseClick()
    {
        WindowManager.instance.Close<MailContentWnd>();
    }
    private void OnBtnGoldClick()
    {
        DataCache.instance.currentCharacter.gold += _mail.money;
        _mail.money = 0;
    }
    private void OnBtnDeleteClick()
    {
        ReqDeleteMail req = new ReqDeleteMail();
        req.mailid = _mail.id;
        NetworkManager.instance.Send((int)MsgID.Delete_Mail_CREQ, req);
    }
}

