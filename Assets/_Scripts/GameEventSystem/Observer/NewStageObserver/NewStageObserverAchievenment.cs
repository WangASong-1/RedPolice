using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class NewStageObserverAchievenment : IGameEventObserver
{
    private NewStageSubject m_Subject;
    private AchievementSystem m_AchSystem;

    public NewStageObserverAchievenment(AchievementSystem m_AchSystem)
    {
        this.m_AchSystem = m_AchSystem;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        m_Subject = sub as NewStageSubject;
    }

    public override void Update()
    {
        m_AchSystem.SetMaxStageLv(m_Subject.StageCount);
    }

    public override void Update(object paremter)
    {
    }
}

