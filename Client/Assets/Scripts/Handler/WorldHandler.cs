using System;
using System.Collections.Generic;
using UnityEngine;
using common;
using proto.scene;

public class WorldHandler : IMsgHandler
{
    public void RegisterMsg(Dictionary<MsgID, Action<SocketModel>> handlers)
    {
        handlers.Add(MsgID.SCENE_Char_SRES, OnSceneChar);
        handlers.Add(MsgID.SCENE_CharOnline_NOTIFY, OnSceneCharOnline);
        handlers.Add(MsgID.SCENE_CharOffline_NOTIFY, OnSceneCharOffline);
        handlers.Add(MsgID.SCENE_CharMove_Notify, OnCharMove);
    }

    /// <summary>
    /// 获取场景中的其他玩家信息的应答
    /// </summary>
    /// <param name="model"></param>
    private void OnSceneChar(SocketModel model)
    {
        if (model.message == null) return;
        RespSceneCharacters resp = SerializeUtil.Deserialize<RespSceneCharacters>(model.message);
        for(int i = 0; i < resp.characters.Count; i++)
        {
            CharacterDTO dto = resp.characters[i];
            RoleCfg cfg = ConfigManager.instance.GetRoleCfg(dto.cfgid);
            Vector3 pos = new Vector3(dto.pos_x, dto.pos_y, dto.pos_z);
            CharacterManager.instance.Create(dto.id, cfg, pos, typeof(OtherPlayer));
        }
    }

    /// <summary>
    /// 场景中进入了新的玩家
    /// </summary>
    /// <param name="model"></param>
    private void OnSceneCharOnline(SocketModel model)
    {
        NotifyCharacterOnline notify = SerializeUtil.Deserialize<NotifyCharacterOnline>(model.message);
        RoleCfg cfg = ConfigManager.instance.GetRoleCfg(notify.character.cfgid);
        Vector3 pos = new Vector3(notify.character.pos_x, notify.character.pos_y, notify.character.pos_z);
        CharacterManager.instance.Create(notify.character.id, cfg, pos, typeof(OtherPlayer));
    }

    /// <summary>
    /// 场景中离开了玩家
    /// </summary>
    /// <param name="model"></param>
    private void OnSceneCharOffline(SocketModel model)
    {
        NotifyCharacterOffline notify = SerializeUtil.Deserialize<NotifyCharacterOffline>(model.message);
        Character ch = CharacterManager.instance.GetCharacter(notify.characterid);
        ch.Leave();
        CharacterManager.instance.Remove(notify.characterid);
    }

    /// <summary>
    /// 角色移动应答
    /// </summary>
    /// <param name="model"></param>
    private void OnCharMove(SocketModel model)
    {
        NotifyCharacterMove notify = SerializeUtil.Deserialize<NotifyCharacterMove>(model.message);

        // 获取哪个玩家移动了
        Character ch = CharacterManager.instance.GetCharacter(notify.characterid);

        Vector3 pos = new Vector3(notify.pos.x, notify.pos.y, notify.pos.z);
        ch.Move(pos);
    }
}