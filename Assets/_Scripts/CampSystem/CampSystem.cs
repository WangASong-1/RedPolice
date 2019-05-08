
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

/// <summary>
/// 兵营系统管理类
/// </summary>
public class CampSystem : IGameSystem {
    private Dictionary<SoldierType, SoldierCamp> mDic_SoldierCamps = new Dictionary<SoldierType, SoldierCamp>();
    private Dictionary<EnemyType, CaptiveCamp> mDic_CaptiveCamps = new Dictionary<EnemyType, CaptiveCamp>();

    public CampSystem() {
    }

    public override void Init()
    {
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);

        InitCamp(EnemyType.Elf);
    }

    private void InitCamp(SoldierType soldierType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = null;
        string icon = null;
        Vector3 position = Vector3.zero;
        float trainTime = 0f;
        //aSong:这个switch可以用文档加载的方式解决
        switch (soldierType)
        {
            case SoldierType.Rookie:
                gameObjectName = "SoldierCamp_Rookie";
                name = "新手兵营";
                icon = "RookieCamp";
                trainTime = 3f;
                break;
            case SoldierType.Sergeant:
                gameObjectName = "SoldierCamp_Sergeant";
                name = "中士兵营";
                icon = "SergeantCamp";
                trainTime = 4f;
                break;
            case SoldierType.Captain:
                gameObjectName = "SoldierCamp_Captain";
                name = "上尉兵营";
                icon = "CaptainCamp";
                trainTime = 5f;
                break;
            default:
                Debug.LogError("无法匹配到指定战士类型 [" + soldierType + "]初始化兵营");
                break;
        }
        gameObject = GameObject.Find(gameObjectName);
        position = gameObject.FindChildTraversing("TrainPoint").transform.position;
        SoldierCamp camp = new SoldierCamp(gameObject, name, icon, soldierType, position, trainTime);

        gameObject.AddComponent<CampOnClick>().Camp = camp;

        mDic_SoldierCamps.Add(soldierType, camp);
    }

    private void InitCamp(EnemyType enemyType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = null;
        string icon = null;
        Vector3 position = Vector3.zero;
        float trainTime = 0f;
        //aSong:这个switch可以用文档加载的方式解决.将EnemyType转换为string类型,部分匹配字段
        switch (enemyType)
        {
            case EnemyType.Elf:
                gameObjectName = "CaptiveCamp_Elf";
                name = "俘兵营";
                icon = "CaptiveCamp";
                trainTime = 3f;
                break;
            default:
                Debug.LogError("无法匹配到指定敌人类型 [" + enemyType + "]初始化兵营");
                break;
        }
        Debug.Log("gameObjectName = " + gameObjectName);
        gameObject = GameObject.Find(gameObjectName);
        position = gameObject.FindChildTraversing("TrainPoint").transform.position;
        CaptiveCamp camp = new CaptiveCamp(gameObject, name, icon, enemyType, position, trainTime);
       
        gameObject.AddComponent<CampOnClick>().Camp = camp;

        mDic_CaptiveCamps.Add(enemyType, camp);
    }

    public override void Release()
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        foreach(SoldierCamp camp in mDic_SoldierCamps.Values)
        {
            camp.Update();
        }

        foreach (CaptiveCamp camp in mDic_CaptiveCamps.Values)
        {
            camp.Update();
        }
    }
}