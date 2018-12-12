
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

/// <summary>
/// 成就系统管理类
/// </summary>
public class AchievementSystem : IGameSystem {

    private int m_EnemyKilledCount = 0;
    private int m_SoldierKilledCount = 0;
    private int m_MaxStageLv = 1;

    public override void Init()
    {
        base.Init();
        m_Facade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverAchievement(this));
        m_Facade.RegisterObserver(GameEventType.SoldierKilled, new SoldierKilledObserverAchievement(this));
        m_Facade.RegisterObserver(GameEventType.NewStage, new NewStageObserverAchievenment(this));
    }

    public void AddEnemyKilledCount(int number = 1)
    {
        m_EnemyKilledCount += number;
        Debug.Log("AchievementSystem::AddEnemyKilledCount 累计杀死的敌人数量 = " + m_EnemyKilledCount);
    }

    public void AddSoldierKilledCount(int number = 1)
    {
        m_SoldierKilledCount += number;
        Debug.Log("AchievementSystem::AddSoldierKilledCount 累计死亡的士兵数量 = " + m_SoldierKilledCount);
    }

    public void SetMaxStageLv(int stageLv)
    {
        if(m_MaxStageLv < stageLv)
        {
            m_MaxStageLv = stageLv;
            Debug.Log("AchievementSystem::SetMaxStageLv 最高关卡 = " + m_MaxStageLv);
        }
    }

    //成就系统本来只负责成就管理的.不应该附加额外职能,并且还会造成数据碎片化,所以这里使用备忘录模式
    public AchievementMemento CreateMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.EnemyKilledCount = m_EnemyKilledCount;
        memento.SoldierKilledCount = m_SoldierKilledCount;
        memento.MaxStageLv = m_MaxStageLv;
        return memento;
    }

    public void SetMemento(AchievementMemento memento)
    {
        Debug.Log("AchievementSystem::SetMemento 累计死亡的士兵数量 = " + m_SoldierKilledCount);

        m_EnemyKilledCount = memento.EnemyKilledCount;
        m_SoldierKilledCount = memento.SoldierKilledCount;
        m_MaxStageLv = memento.MaxStageLv;
    }
}