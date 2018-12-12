
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

/// <summary>
/// 能量管理系统
/// </summary>
public class EnergySystem : IGameSystem {
    private const int Max_Energy = 100;
    private float m_NowEnergy = Max_Energy;
    private float m_RecoverSpeed = 3;

    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        base.Update();
        m_Facade.UpdateEnergySlider((int)m_NowEnergy, Max_Energy);

        if (m_NowEnergy >= Max_Energy) return;
        m_NowEnergy += m_RecoverSpeed * Time.deltaTime;
        m_NowEnergy = Mathf.Min(m_NowEnergy, Max_Energy);
    }

    public bool TakeEnergy(int value)
    {
        if(m_NowEnergy >= value)
        {
            m_NowEnergy -= value;
            return true;
        }

        return false;
    }

    public void RecycleEnergy(int value)
    {
        m_NowEnergy += value;
        m_NowEnergy = Mathf.Min(m_NowEnergy, Max_Energy);
    }
}