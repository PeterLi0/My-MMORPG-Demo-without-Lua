using System;
using System.Collections.Generic;
using UnityEngine;

public enum SceneType
{
    Loading = 1,
    Login = 2,
    SelectRole = 3,
    MainCity = 4,
    Battle = 5
}

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
        ConfigManager.instance.Initialize(new ConfigParser());


        WindowManager.instance.Initialize();
        NetworkManager.instance.Initialize();

        Loading.instance.LoadScene("Login");
    }

    void OnLevelWasLoaded(int level)
    {
        if(level == (int)SceneType.Loading)
        {
            Loading.instance.Initialize();
        }
        else if(level == (int)SceneType.Login)
        {
            Login.instance.Initialize();
        }
        else if(level == (int)SceneType.SelectRole)
        {
            SelectRole.instance.Initialize();
        }
        else if(level == (int)SceneType.MainCity)
        {
            MainCity.instance.Initialize();
        }
        else if(level >= (int)SceneType.Battle)
        {
            Battle.instance.Initialize();
        }
    }

    void Update()
    {
        float dt = Time.deltaTime;
        TimerManager.instance.Update(dt);
        WindowManager.instance.Update(dt);
        CharacterManager.instance.Update(dt);
        SkillManager.instance.Update(dt);
        NetworkManager.instance.Update();
    }

    void OnApplicationQuit()
    {
        // 断开连接
        NetworkManager.instance.Disconnect();
    }
}