using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class EnemyKilledSubject : IGameEventSubject
{
    private int m_KilledCount = 0;
    public int KilledCount { get { return m_KilledCount; } }

    public override void Notify()
    {
        m_KilledCount++;
        base.Notify();
    }
}

