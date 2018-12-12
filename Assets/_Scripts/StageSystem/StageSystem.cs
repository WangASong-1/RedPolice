
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

/// <summary>
/// 关卡管理类
/// 使用责任链模式来管理关卡进度
/// 使用观察者模式 监控游戏内敌人死亡的数量
/// </summary>
public class StageSystem : IGameSystem {
    int m_lv = 1;
    List<Vector3> m_PosList;
    IStageHandler m_RootHandler;
    Vector3 m_TargetPosition;
    int m_CountOfEnemyKilled = 0;

    public override void Init()
    {
        base.Init();
        InitPosition();
        InitStageChain();
        m_Facade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverStageSystem(this));
    }

    public override void Update()
    {
        base.Update();
        m_RootHandler.Handle(m_lv);
    }

    private void InitPosition()
    {
        m_PosList = new List<Vector3>();
        int i = 1;
        while (true)
        {
            GameObject go = GameObject.Find("Position" + i);
            if(go != null)
            {
                i++;
                m_PosList.Add(go.transform.position);
                go.SetActive(false);
            }
            else { break; }
        }

        GameObject target = GameObject.Find("TargetPosition");
        //target.SetActive(false);
        m_TargetPosition = target.transform.position;
    }

    private Vector3 GetRandomPos()
    {
        return m_PosList[UnityEngine.Random.Range(0, m_PosList.Count)];
    }

    private void InitStageChain()
    {
        int lv = 1;
        NormalStageHandler handler1 = new NormalStageHandler(this, lv++, 3, EnemyType.Elf, WeaponType.Gun, 3,GetRandomPos());
        NormalStageHandler handler2 = new NormalStageHandler(this, lv++, 6, EnemyType.Elf, WeaponType.Rifle, 3,GetRandomPos());
        NormalStageHandler handler3 = new NormalStageHandler(this, lv++, 9, EnemyType.Elf, WeaponType.Rocket, 3,GetRandomPos());
        NormalStageHandler handler4 = new NormalStageHandler(this, lv++, 13, EnemyType.Ogre, WeaponType.Gun, 4,GetRandomPos());
        NormalStageHandler handler5 = new NormalStageHandler(this, lv++, 17, EnemyType.Ogre, WeaponType.Rifle, 4,GetRandomPos());
        NormalStageHandler handler6 = new NormalStageHandler(this, lv++, 21, EnemyType.Ogre, WeaponType.Rocket, 4,GetRandomPos());
        NormalStageHandler handler7 = new NormalStageHandler(this, lv++, 26, EnemyType.Troll, WeaponType.Gun, 5,GetRandomPos());
        NormalStageHandler handler8 = new NormalStageHandler(this, lv++, 31, EnemyType.Troll, WeaponType.Rocket, 5,GetRandomPos());
        NormalStageHandler handler9 = new NormalStageHandler(this, lv++, 36, EnemyType.Troll, WeaponType.Rocket, 5,GetRandomPos());


        handler1.SetNextHandler(handler2)
            .SetNextHandler(handler3)
            .SetNextHandler(handler4)
            .SetNextHandler(handler5)
            .SetNextHandler(handler6)
            .SetNextHandler(handler7)
            .SetNextHandler(handler8)
            .SetNextHandler(handler9);

        m_RootHandler = handler1;
    }
    public int GetCountOfEnemyKilled()
    {
        return m_CountOfEnemyKilled;
    }

    public int CountOfEnemyKilled
    {
        set { m_CountOfEnemyKilled = value; }
    }
    
    public void EnterNextStage()
    {
        m_lv++;
        m_Facade.NotyfySubject(GameEventType.NewStage);
    }

    public Vector3 TargetPosition
    {
        get { return m_TargetPosition; }
    }
}