using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using proto.inventory;
using proto.character;
using proto.mail;
using task;
using proto.mall;


public class MainWnd : BaseWnd
{
    public void Initialize()
    {
        Button bagBtn = _transform.FindChild("BtnBag").GetComponent<Button>();
        bagBtn.onClick.AddListener(OnBagBtnClicked);

        Button storeBtn = _transform.FindChild("BtnStore").GetComponent<Button>();
        storeBtn.onClick.AddListener(OnStoreBtnClicked);

        // 战斗按钮
        Button battleBtn = _transform.FindChild("BtnBattle").GetComponent<Button>();
        battleBtn.onClick.AddListener(OnBattleBtnClick);

        // 返回按钮
        Button returnBtn = _transform.FindChild("BtnReturn").GetComponent<Button>();
        returnBtn.onClick.AddListener(OnReturnBtnClick);

        Button btnMail = _transform.FindChild("BtnMail").GetComponent<Button>();
        btnMail.onClick.AddListener(OnBtnMailClick);

        // 任务按钮
        Button btnTask = _transform.FindChild("BtnTask").GetComponent<Button>();
        btnTask.onClick.AddListener(OnBtnTaskClick);
    }

    private void OnBagBtnClicked()
    {
        ReqGetItemInfo req = new ReqGetItemInfo();
        NetworkManager.instance.Send((int)MsgID.INV_ItemInfos_CREQ,req);
    }

    private void OnStoreBtnClicked()
    {
        ReqMallInfo req = new ReqMallInfo();
        NetworkManager.instance.Send((int)MsgID.MallInfo_CREQ, req);
    }

    private void OnBattleBtnClick()
    {
        WindowManager.instance.Open<SelectLevelWnd>().Initialize();
    }

    private void OnBtnMailClick()
    {
        ReqMailInfos req = new ReqMailInfos();
        NetworkManager.instance.Send((int)MsgID.MailInfos_CREQ, req);
    }

    private void OnReturnBtnClick()
    {
        // 请求角色离线
        ReqCharacterOffline req = new ReqCharacterOffline();
        NetworkManager.instance.Send((int)MsgID.CHAR_OFFLINE_CREQ, req);
    }

    private void OnBtnTaskClick()
    {
        ReqTaskInfo reqTask = new ReqTaskInfo();
        NetworkManager.instance.Send((int)MsgID.Info_CREQ, reqTask);
    }
}