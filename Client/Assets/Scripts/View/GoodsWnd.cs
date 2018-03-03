using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using common;

/// <summary>
/// 商品界面
/// </summary>
public class GoodsWnd : BaseWnd
{       
    public void Initialize(ItemCfg itemCfg, MallCfg mallCfg)
    {
        // 物品图片
        Image itemImage = _transform.FindChild("GoodsImage/Image").GetComponent<Image>();
        itemImage.overrideSprite = Resources.Load<Sprite>("Icon/" + itemCfg.Icon);
        // 金币余额
        Text gold = _transform.FindChild("TitleImg/GoldInfo/TxtGold").GetComponent<Text>();
        gold.text = DataCache.instance.currentCharacter.gold.ToString();
        // 钻石余额
        Text diamond = _transform.FindChild("TitleImg/GoldInfo/TxtDiamond").GetComponent<Text>();
        diamond.text = DataCache.instance.currentCharacter.diamond.ToString();
        // 物品名字
        Text itemName = _transform.FindChild("GoodsContent/Name").GetComponent<Text>();
        itemName.text = itemCfg.Name;
        // 物品描述
        Text itemDescription = _transform.FindChild("GoodsContent/Text").GetComponent<Text>();
        itemDescription.text = string.Format("{0}\n属性:\n\n\n价格:\n金币:{1}\n钻石:{2}", itemCfg.Name, mallCfg.Gold, mallCfg.Diamond);
        // 返回按钮
        Button btnClose = _transform.FindChild("TitleImg/BtnReturn").GetComponent<Button>();
        btnClose.onClick.AddListener(OnBtnClose);
    }
    
    private void OnBtnClose()
    {
        WindowManager.instance.Close<GoodsWnd>();
    }
}