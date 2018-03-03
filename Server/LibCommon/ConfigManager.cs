//using UnityEngine;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Reflection;


public abstract class IConfigParser
{
    public abstract Dictionary<int, T> LoadConfig<T>(string tablename);

    protected T GreateAndSetValue<T>(XmlElement node)
    {
        // 通过类型创建一个对象实例
        T obj = Activator.CreateInstance<T>();

        // 获取一个类的所有字段
        FieldInfo[] fields = typeof(T).GetFields();

        for (int i = 0; i < fields.Length; i++)
        {
            string name = fields[i].Name;
            if (string.IsNullOrEmpty(name)) continue;

            string fieldValue = node.GetAttribute(name);
            if (string.IsNullOrEmpty(fieldValue)) continue;

            try
            {
                ParsePropertyValue<T>(obj, fields[i], fieldValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("XML读取错误：对象类型({2}) => 属性名({0}) => 属性类型({3}) => 属性值({1})",
                    fields[i].Name, fieldValue, typeof(T).ToString(), fields[i].FieldType.ToString()));
            }
        }
        return obj;
    }


    private void ParsePropertyValue<T>(T obj, FieldInfo fieldInfo, string valueStr)
    {
        System.Object value = valueStr;

        // 将字符串解析为类中定义的类型
        if (fieldInfo.FieldType.IsEnum)
            value = Enum.Parse(fieldInfo.FieldType, valueStr);
        else
        {
            if (fieldInfo.FieldType == typeof(int))
                value = int.Parse(valueStr);
            else if (fieldInfo.FieldType == typeof(byte))
                value = byte.Parse(valueStr);
            else if (fieldInfo.FieldType == typeof(bool))
                value = bool.Parse(valueStr);
            else if (fieldInfo.FieldType == typeof(float))
                value = float.Parse(valueStr);
            else if (fieldInfo.FieldType == typeof(double))
                value = double.Parse(valueStr);
            else if (fieldInfo.FieldType == typeof(uint))
                value = uint.Parse(valueStr);
            else if (fieldInfo.FieldType == typeof(ulong))
                value = ulong.Parse(valueStr);
        }

        if (value == null)
            return;

        fieldInfo.SetValue(obj, value);
    }
}
/// <summary>
/// 游戏配置管理器
/// </summary>
public class ConfigManager : Singleton<ConfigManager>
{
    private IConfigParser _configParser;

    public Dictionary<int, LevelCfg> levelCfgs = new Dictionary<int, LevelCfg>();

    private Dictionary<int, BornPointCfg> _bornPoints = new Dictionary<int, BornPointCfg>();

    public Dictionary<int, RoleCfg> roleCfgs = new Dictionary<int, RoleCfg>();

    // 技能组配置
    private Dictionary<int, SkillGroupCfg> _skillGroupCfgs = new Dictionary<int, SkillGroupCfg>();

    // 技能基础配置
    private Dictionary<int, SkillBasicCfg> _skillBasicCfgs = new Dictionary<int, SkillBasicCfg>();

    // 子弹配置
    private Dictionary<int, SkillBulletCfg> _skillBulletCfgs = new Dictionary<int, SkillBulletCfg>();

    // AOE配置
    private Dictionary<int, SkillAOECfg> _skillAOECfgs = new Dictionary<int, SkillAOECfg>();

    // Buff配置
    private Dictionary<int, SkillBuffCfg> _skillBuffCfgs = new Dictionary<int, SkillBuffCfg>();

    // 陷阱配置
    private Dictionary<int, SkillTrapCfg> _skillTrapCfgs = new Dictionary<int, SkillTrapCfg>();

    // 消息提示配置
    public Dictionary<int, MsgTipsCfg> _msgTipsCfgs = new Dictionary<int, MsgTipsCfg>();

    private Dictionary<int, ItemCfg> _itemCfgs = new Dictionary<int, ItemCfg>();

    // 商城配置
    public Dictionary<int, MallCfg> mallCfgs = new Dictionary<int, MallCfg>();

    // 任务配置
    public Dictionary<int, TaskCfg> _taskCfgs = new Dictionary<int, TaskCfg>();

    public void Initialize(IConfigParser configParser)
    {
        _configParser = configParser;
        LoadAllConfigs();
    }

    /// <summary>
    /// 载入所有游戏配置
    /// </summary>
    public void LoadAllConfigs()
    {
        levelCfgs = _configParser.LoadConfig<LevelCfg>("Level");
        _bornPoints = _configParser.LoadConfig<BornPointCfg>("BornPoint");
        roleCfgs = _configParser.LoadConfig<RoleCfg>("Role");
        _skillGroupCfgs = _configParser.LoadConfig<SkillGroupCfg>("SkillGroup");
        _skillBasicCfgs = _configParser.LoadConfig<SkillBasicCfg>("SkillBasic");
        _skillBulletCfgs = _configParser.LoadConfig<SkillBulletCfg>("SkillBullet");
        _skillAOECfgs = _configParser.LoadConfig<SkillAOECfg>("SkillAOE");
        _skillBuffCfgs = _configParser.LoadConfig<SkillBuffCfg>("SkillBuff");
        _skillTrapCfgs = _configParser.LoadConfig<SkillTrapCfg>("SkillTrap");
        _msgTipsCfgs = _configParser.LoadConfig<MsgTipsCfg>("MsgTips");
        _itemCfgs = _configParser.LoadConfig<ItemCfg>("Item");
        mallCfgs = _configParser.LoadConfig<MallCfg>("Mall");
        _taskCfgs = _configParser.LoadConfig<TaskCfg>("Task");
    }

    /// <summary>
    /// 通过关卡ID获取关卡配置
    /// </summary>
    /// <param name="levelID"></param>
    /// <returns></returns>
    public LevelCfg GetLevelCfg(int levelID)
    {
        return levelCfgs[levelID];
    }

    /// <summary>
    /// 获取某一个关卡中的所有出生点配置
    /// </summary>
    /// <param name="levelID"></param>
    /// <returns></returns>
    public Dictionary<int, BornPointCfg> GetBornPoints(int levelID)
    {
        Dictionary<int, BornPointCfg> bornPointCfgs = new Dictionary<int, BornPointCfg>();
        foreach(BornPointCfg bpc in _bornPoints.Values)
        {
            if (bpc.LevelID == levelID && !bornPointCfgs.ContainsKey(bpc.ID))
                bornPointCfgs.Add(bpc.ID, bpc);
        }

        return bornPointCfgs;
    }

    /// <summary>
    /// 获取角色配置
    /// </summary>
    /// <param name="roleID"></param>
    /// <returns></returns>
    public RoleCfg GetRoleCfg(int roleID)
    {
        return roleCfgs[roleID];
    }

    /// <summary>
    /// 获取某一类型的角色
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public Dictionary<int, RoleCfg> GetTypeRoleCfgs(RoleType type)
    {
        Dictionary<int, RoleCfg> cfgs = new Dictionary<int, RoleCfg>();
        foreach(RoleCfg cfg in roleCfgs.Values)
        {
            if (cfg.RoleType == type)
                cfgs.Add(cfg.ID, cfg);
        }

        return cfgs;
    }

    /// <summary>
    /// 通过技能ID获取技能组信息
    /// </summary>
    /// <param name="roleid"></param>
    /// <returns></returns>
    public Dictionary<int, SkillGroupCfg> GetSkillGroupCfgs(int roleid)
    {
        Dictionary<int, SkillGroupCfg> cfgs = new Dictionary<int, SkillGroupCfg>();
        foreach(SkillGroupCfg cfg in _skillGroupCfgs.Values)
        {
            if (cfg.RoleID == roleid)
                cfgs.Add(cfg.ID, cfg);
        }

        return cfgs;
    }

    /// <summary>
    /// 通过技能ID获取技能基础配置
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public SkillBasicCfg GetSkillBasicCfg(int skillID)
    {
        return _skillBasicCfgs[skillID];
    }

    /// <summary>
    /// 通过技能ID获取子弹类技能配置
    /// </summary>
    /// <param name="skillID"></param>
    /// <returns></returns>
    public SkillBulletCfg GetSkillBulletCfg(int skillID)
    {
        return _skillBulletCfgs.ContainsKey(skillID) ?  _skillBulletCfgs[skillID] : null;
    }

    public SkillAOECfg GetSkillAOECfg(int skillID)
    {
        return _skillAOECfgs.ContainsKey(skillID) ? _skillAOECfgs[skillID] : null;
    }

    public SkillBuffCfg GetSkillBuffCfg(int skillID)
    {
        return _skillBuffCfgs.ContainsKey(skillID)? _skillBuffCfgs[skillID] : null;
    }

    public SkillTrapCfg GetSkillTrapCfg(int skillID)
    {
        return _skillTrapCfgs.ContainsKey(skillID)?  _skillTrapCfgs[skillID]: null;
    }

    /// <summary>
    /// 通过角色ID和技能索引获取技能组配置
    /// </summary>
    /// <param name="roleid"></param>
    /// <param name="skillindex"></param>
    /// <returns></returns>
    public SkillGroupCfg GetSkillGroupCfg(int roleid, int skillindex)
    {
        foreach(SkillGroupCfg cfg in _skillGroupCfgs.Values)
        {
            if (cfg.RoleID == roleid && cfg.Index == skillindex)
                return cfg;
        }
        return null; 
    }

    /// <summary>
    /// 获取消息提示信息的值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetMsgTips(uint key)
    {
        return _msgTipsCfgs[(int)key].Value;
    }

    public ItemCfg GetItemCfg(int key)
    {
        return _itemCfgs[key];
    }
}
