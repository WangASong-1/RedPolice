using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 能量消耗策略
/// </summary>
public abstract class IEnergyCountStrategy
{
    public abstract int GetCampUpgradeCost(SoldierType st,int lv);
    public abstract int GetWeaponUpgradeCost(WeaponType wt);
    public abstract int GetSoldierTrainCost(SoldierType st, int lv);
}

