using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using common;
using proto.mall;


/// <summary>
/// 商城界面
/// </summary>
public class MallWnd : BaseWnd
{
    private Text go;
    private Text di;
    private MallCfg cfg;
    private ItemCfg itemcfg;
    public void Initialize(List<uint> goods)
    {
        Transform _content = _transform.FindChild("Scroll View/Viewport/Content");

        go = _transform.FindChild("Image/GoldInfo/TxtGold").GetComponent<Text>();
        go.text = DataCache.instance.currentCharacter.gold.ToString();
        di = _transform.FindChild("Image/GoldInfo/TxtDiamond").GetComponent<Text>();
        di.text = DataCache.instance.currentCharacter.diamond.ToString();

        Button _btnGoods = _transform.FindChild("Scroll View/Viewport/BtnGoods").GetComponent<Button>();

        Button btnClose = _transform.FindChild("Image/BtnReturn").GetComponent<Button>();
        btnClose.onClick.AddListener(OnBtnClose);

        for (int i = 0; i < goods.Count; i++)
        {
            Transform child = GameObject.Instantiate(_btnGoods.gameObject).transform;
            child.SetParent(_content);
            child.localPosition = Vector3.zero;
            child.localScale = Vector3.one;
            child.gameObject.SetActive(true);            

            cfg = ConfigManager.instance.mallCfgs[(int)goods[i]];
            itemcfg = ConfigManager.instance.GetItemCfg(cfg.ItemID);

            child.gameObject.AddComponent<ButtonEventListener>().thisItemCfg = itemcfg;
            child.gameObject.GetComponent<ButtonEventListener>().thisMallCfg = cfg;

            Button btnBuy = child.FindChild("BtnBuy").GetComponent<Button>();
            btnBuy.gameObject.AddComponent<ButBuyEventListener>().goodsid = goods[i];

            Text name = child.FindChild("Name").GetComponent<Text>();
            name.text = itemcfg.Name;

            Text gold = child.FindChild("Gold").GetComponent<Text>();
            gold.text = cfg.Gold.ToString();

            Text dim = child.FindChild("Diamond").GetComponent<Text>();
            dim.text = cfg.Diamond.ToString();

            Image image = child.FindChild("Image").GetComponent<Image>();
            image.overrideSprite = Resources.Load<Sprite>("Icon/" + itemcfg.Icon);
        }

        
    }
    public class ButtonEventListener : MonoBehaviour, IPointerClickHandler
    {
        public ItemCfg thisItemCfg;
        public MallCfg thisMallCfg;
        public void OnPointerClick(PointerEventData eventData)
        {
            WindowManager.instance.Open<GoodsWnd>().Initialize(thisItemCfg, thisMallCfg);
        }
    }
    public class ButBuyEventListener : MonoBehaviour, IPointerClickHandler
    {
        public uint goodsid;
        public void OnPointerClick(PointerEventData eventData)
        {
            WindowManager.instance.Open<BuyTypeWnd>().Initialize(goodsid);
        }
    }
    private void OnBtnClose()
    {
        WindowManager.instance.Close<MallWnd>();
    }
    public void UpDateGoDi(int gold, int dim)
    {
        go.text = gold.ToString();
        di.text = dim.ToString();
    }
}