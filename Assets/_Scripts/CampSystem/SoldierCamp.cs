using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierCamp : ICamp
{
    const int MAX_LV = 4;
    private int m_Lv = 1;
    private WeaponType m_WeaponType = WeaponType.Gun;

    public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 pos, float trainTime, WeaponType weaponType = WeaponType.Gun, int lv = 1)
        :base(gameObject,name,icon, soldierType, pos, trainTime)
    {
        m_Lv = lv;
        m_WeaponType = weaponType;
        m_EnergyCountStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }

    public override int Lv
    {
        get
        {
            return m_Lv;
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
            if (m_Lv == MAX_LV)
                return -1;
            else
                return m_EnergyCostCampUpgrade;
        }
    }

    public override int EnergyCostWeaponUpgrade {
        get
        {
            if (m_WeaponType + 1 == WeaponType.MAX)
                return -1;
            else
                return m_EnergyCostWeaponUpgrade;
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
        TrainSoldierCommand cmd = new TrainSoldierCommand(m_SoldierType, m_WeaponType, m_Position, m_Lv);
        m_Commands.Add(cmd);
    }

    public override void UpgradeCamp()
    {
        m_Lv++;
        UpdateEnergyCost();
    }

    public override void UpgradeWeapon()
    {
        m_WeaponType = m_WeaponType + 1;
        UpdateEnergyCost();
    }

    protected override void UpdateEnergyCost()
    {
        m_EnergyCostCampUpgrade = m_EnergyCountStrategy.GetCampUpgradeCost(m_SoldierType,m_Lv);
        m_EnergyCostWeaponUpgrade = m_EnergyCountStrategy.GetWeaponUpgradeCost(m_WeaponType);
        m_EnergyCostTrain = m_EnergyCountStrategy.GetSoldierTrainCost(m_SoldierType,m_Lv);
    }
}

