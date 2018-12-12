using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierEnergyCostStrategy : IEnergyCountStrategy
{
    public override int GetCampUpgradeCost(SoldierType st, int lv)
    {
        int energy = 0;
        //aSong:文档加载方式解决.将士兵和敌人动态的数据统一放在文件中.加载进来后用Dic来保存Struct
        switch (st)
        {
            case SoldierType.Rookie:
                energy = 60;
                break;
            case SoldierType.Sergeant:
                energy = 65;
                break;
            case SoldierType.Captain:
                energy = 70;
                break;
            default:
                Debug.Log("无法获取兵营类型 [" + st + "] 升级所消耗的能量值");
                break;
        }
        energy += (lv - 1) * 2;
        if (energy > 100) energy = 100;
        return energy;
    }

    public override int GetSoldierTrainCost(SoldierType st, int lv)
    {
        int energy = 0;
        //aSong:文档加载方式解决.将士兵和敌人动态的数据统一放在文件中.加载进来后用Dic来保存Struct
        switch (st)
        {
            case SoldierType.Rookie:
                energy = 10;
                break;
            case SoldierType.Sergeant:
                energy = 15;
                break;
            case SoldierType.Captain:
                energy = 20;
                break;
            case SoldierType.Captive:
                return 10;
            default:
                Debug.Log("无法获取士兵类型 [" + st + "] 训练所消耗的能量值");
                break;
        }
        energy += (lv - 1) * 2;
        if (energy > 100) energy = 100;
        return energy;
    }

    public override int GetWeaponUpgradeCost(WeaponType wt)
    {
        int energy = 0;
        //aSong:文档加载方式解决.将士兵和敌人动态的数据统一放在文件中.加载进来后用Dic来保存Struct
        switch (wt)
        {
            case WeaponType.Gun:
                energy = 30;
                break;
            case WeaponType.Rifle:
                energy = 40;
                break;
            default:
                Debug.Log("无法获取 类型 [" + wt + "] 升级所消耗的能量值");
                break;
        }
        return energy;
    }
}

