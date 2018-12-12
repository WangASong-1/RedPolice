using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierKilledObserverAchievement : IGameEventObserver
{
    private AchievementSystem m_AchSystem;

    public SoldierKilledObserverAchievement(AchievementSystem m_AchSystem)
    {
        this.m_AchSystem = m_AchSystem;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        return;
    }

    public override void Update()
    {
        m_AchSystem.AddSoldierKilledCount();
    }

    public override void Update(object paremter)
    {
    }
}

