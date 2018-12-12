using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class NewStageSubject : IGameEventSubject
{
    private int m_StageCount = 1;
    public int StageCount { get { return m_StageCount; } }

    public override void Notify()
    {
        //先自增再通知,不然若是先通知再自增,给出的值不变
        m_StageCount++;
        base.Notify();
    }
}

