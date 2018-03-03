using System;
using System.Collections.Generic;


public class World : Singleton<World>
{
    public Dictionary<int, Player> players = new Dictionary<int, Player>();

    /// <summary>
    /// 判断玩家是否在世界中
    /// </summary>
    /// <param name="characterid"></param>
    /// <returns></returns>
    public bool IsPlayerInWorld(int characterid)
    {
        return players.ContainsKey(characterid);
    }

    /// <summary>
    /// 进入世界
    /// </summary>
    /// <param name="p"></param>
    public void EnterWorld(Player p)
    {
        players.Add(p.globalid, p);
    }

    /// <summary>
    /// 离开世界
    /// </summary>
    /// <param name="characterid"></param>
    public void LeaveWorld(int characterid)
    {
        players.Remove(characterid);
    }
}