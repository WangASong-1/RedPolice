using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察EnemyKilled事件,由StageSystem观察
/// </summary>
public class EnemyKilledObserverStageSystem : IGameEventObserver
{
    private EnemyKilledSubject m_Subject;
    private StageSystem m_StageSystem;
    public EnemyKilledObserverStageSystem(StageSystem ss)
    {
        this.m_StageSystem = ss;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        m_Subject = sub as EnemyKilledSubject;
    }

    public override void Update()
    {
        m_StageSystem.CountOfEnemyKilled = m_Subject.KilledCount;
    }

    public override void Update(object paremter)
    {
    }
}

