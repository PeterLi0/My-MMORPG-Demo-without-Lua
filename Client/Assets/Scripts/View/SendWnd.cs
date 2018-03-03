using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using common;
using proto.mail;
public class SendWnd : BaseWnd
{
    private Button _btnClose;
    private Button _btnSend;
    private InputField _input;
    private InputField _ID;
    private InputField _title;
    private InputField _gold;
    public void Init()
    {
        _btnClose = _transform.FindChild("BtnClose").GetComponent<Button>();
        _btnSend = _transform.FindChild("BtnSend").GetComponent<Button>();
        _ID = _transform.FindChild("ID").GetComponent<InputField>();
        _input = _transform.FindChild("Content").GetComponent<InputField>();
        _title = _transform.FindChild("Title").GetComponent<InputField>();
        _gold = _transform.FindChild("Golds").GetComponent<InputField>();
        _btnClose.onClick.AddListener(OnBtnClose);
        _btnSend.onClick.AddListener(OnBtnSend);
    }
    private void OnBtnClose()
    {
        // WindowManager.instance.Open<MailWnd>();
        WindowManager.instance.Close<SendWnd>();
    }
    private void OnBtnSend()
    {
        ReqSendMail reqSend = new ReqSendMail();
        reqSend.dto = new MailDTO();
        reqSend.dto.body = _input.text;
        reqSend.dto.subject = _title.text;
        reqSend.dto.deliver_time = DateTime.Now.ToString();
        reqSend.dto.receiver_id = int.Parse(_ID.text);
        reqSend.dto.money = string.IsNullOrEmpty(_gold.text) ? 0 : int.Parse(_gold.text);
        Debug.Log("发送");
        NetworkManager.instance.Send((int)MsgID.Send_CREQ, reqSend);
    }
}
