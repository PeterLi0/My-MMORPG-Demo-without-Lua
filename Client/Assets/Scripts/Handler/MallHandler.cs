using proto.mall;
using System;
using System.Collections.Generic;

public class MallHandler : IMsgHandler
{
    public void RegisterMsg(Dictionary<MsgID, Action<SocketModel>> handlers)
    {
        handlers.Add(MsgID.MallInfo_SRES, OnMallInfos);
        handlers.Add(MsgID.BuyGoods_SRES, OnBuyGoods);
    }
    private void OnMallInfos(SocketModel model)
    {
        RspMallInfo resp = SerializeUtil.Deserialize<RspMallInfo>(model.message);

        WindowManager.instance.Open<MallWnd>().Initialize(resp.goods);
    }

    private void OnBuyGoods(SocketModel model)
    {
        RspBuyGoods resp = SerializeUtil.Deserialize<RspBuyGoods>(model.message);
        if (resp.msgtips == (uint)MsgTips.BuyGoodsSuccess)
        {
            //关闭选择购买方式方法窗口
            WindowManager.instance.Close<BuyTypeWnd>();

            //更新缓存中钻石和金币数量
            DataCache.instance.currentCharacter.gold = (int)resp.gold;
            DataCache.instance.currentCharacter.diamond = (int)resp.diamond;
            WindowManager.instance.Get<MallWnd>().UpDateGoDi((int)resp.gold, (int)resp.diamond);
            MessageBox.Show("购买成功");
        }
        else if (resp.msgtips == (uint)MsgTips.GoldNotEnough)
        {
            MessageBox.Show("金币不足");
        }
        else if (resp.msgtips == (uint)MsgTips.DiamondNotEnough)
        {
            MessageBox.Show("钻石不足");
        }
    }


}