using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 俘兵营
/// </summary>
public class CaptiveCamp : ICamp
{
    private WeaponType m_WeaponType = WeaponType.Gun;
    private EnemyType m_EnemyType;

    public CaptiveCamp(GameObject gameObject, string name, string icon, EnemyType enemyType, Vector3 pos, float trainTime)
        : base(gameObject, name, icon, SoldierType.Captive, pos, trainTime)
    {
        m_EnemyType = enemyType;
        m_EnergyCountStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }

    public override int Lv
    {
        get
        {
            return 1;
        }
    }

    public override WeaponType WeaponType
    {
        get
        {
            return m_WeaponType;
        }
    }

    public override int EnergyCostCampUpgrade
    {
        get
        {
            return 0;
        }
    }

    public override int EnergyCostWeaponUpgrade
    {
        get
        {
            return 0;
        }
    }

    public override int EnergyCostTrain
    {
        get
        {
            return m_EnergyCostTrain;
        }
    }
    public override void Train()
    {
        TrainCaptiveCommand cmd = new TrainCaptiveCommand(m_EnemyType, m_WeaponType, m_Position);
        m_Commands.Add(cmd);
    }

    public override void UpgradeCamp()
    {
        return;
    }

    public override void UpgradeWeapon()
    {
        return;
    }

    protected override void UpdateEnergyCost()
    {
        //m_EnergyCostCampUpgrade = m_EnergyCountStrategy.GetCampUpgradeCost(m_SoldierType, m_Lv);
        //m_EnergyCostWeaponUpgrade = m_EnergyCountStrategy.GetWeaponUpgradeCost(m_WeaponType);
        m_EnergyCostTrain = m_EnergyCountStrategy.GetSoldierTrainCost(m_SoldierType, 1);
    }
}

