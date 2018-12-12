using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 成就系统观察敌人死亡
/// </summary>
public class EnemyKilledObserverAchievement : IGameEventObserver
{
    //不需要获取主题的参数,所以就不需要设置主题
    //private EnemyKilledSubject m_Subject;
    private AchievementSystem m_AchSystem;

    public EnemyKilledObserverAchievement(AchievementSystem m_AchSystem)
    {
        this.m_AchSystem = m_AchSystem;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        //m_Subject = sub as EnemyKilledSubject;
    }

    public override void Update()
    {
        m_AchSystem.AddEnemyKilledCount();
    }

    public override void Update(object paremter)
    {
        
    }
}

