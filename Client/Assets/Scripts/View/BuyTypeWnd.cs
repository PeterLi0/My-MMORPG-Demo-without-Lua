using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using common;
using proto.mall;
/// <summary>
/// 选择购买方式界面
/// </summary>
public class BuyTypeWnd : BaseWnd
{
    private uint _goodsid;
    public void Initialize(uint goodsid)
    {
        _goodsid = goodsid;

        Button btnGold = _transform.FindChild("BtnGold").GetComponent<Button>();
        btnGold.onClick.AddListener(OnBtnGold);

        Button btnDiamond = _transform.FindChild("BtnDiamond").GetComponent<Button>();
        btnDiamond.onClick.AddListener(OnBtnDiamond);

        Button btnClose = _transform.FindChild("BtnReturn").GetComponent<Button>();
        btnClose.onClick.AddListener(OnBtnClose);
    }
    private void OnBtnGold()
    {
        ReqBuyGoods req = new ReqBuyGoods();
        req.goodid = (uint)_goodsid;
        req.buyType = BuyType.Gold;
       // WindowManager.instance.Close<BuyTypeWnd>();
        NetworkManager.instance.Send((int)MsgID.BuyGoods_CREQ, req);
    }
    private void OnBtnDiamond()
    {
        ReqBuyGoods req = new ReqBuyGoods();
        req.goodid = (uint)_goodsid;
        req.buyType = BuyType.Diamon;
        //WindowManager.instance.Close<BuyTypeWnd>();
        NetworkManager.instance.Send((int)MsgID.BuyGoods_CREQ, req);
    }
    private void OnBtnClose()
    {
        WindowManager.instance.Close<BuyTypeWnd>();
    }
}
