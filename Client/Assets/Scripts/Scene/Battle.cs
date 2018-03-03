using System;
using System.Collections.Generic;


public class Battle : Singleton<Battle>, IScene
{
    //public LevelCfg levelCfg;

    public void Initialize()
    {
        WindowManager.instance.Close<LoadingWnd>();
        BattleWnd battleWnd = WindowManager.instance.Open<BattleWnd>().Initialize();

        int levelID = DataCache.instance.currentLevelCfg.ID;
        Dictionary<int, BornPointCfg> bpcs = ConfigManager.instance.GetBornPoints(levelID);
        foreach(BornPointCfg bpc in bpcs.Values)
        {
            int roleid = bpc.RoleID == 0 ? DataCache.instance.currentCharacter.cfgid : bpc.RoleID;

            // 通过角色ID获取角色配置
            RoleCfg roleCfg = ConfigManager.instance.GetRoleCfg(roleid);

            // 创建角色
            Character character = CharacterManager.instance.Create(roleCfg, MathTools.GetPosition(bpc.Position));

            character.side = roleCfg.RoleType == RoleType.Player ? RoleSide.Blue : RoleSide.Red;

            // 战斗界面监听战斗中的事件
            character.hpChanged = battleWnd.CreateBloodText;
            character.characterDie = battleWnd.OnCharacterDie;

            // 角色创建
            battleWnd.OnCharacterCreate(character);
        }
    }

    public void Finalise()
    {
        CharacterManager.instance.Clear();
        SkillManager.instance.Clear();
        PoolManager.instance.Clear();
        TimerManager.instance.Clear();
        WindowManager.instance.Close<BattleWnd>();
    }
}

