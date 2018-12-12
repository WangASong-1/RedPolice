using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 武器工厂,创建指定武器
/// </summary>
public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;
        WeaponBaseAttr baseAttr = FactoryManager.AttrFactory.GetWeaponBaseAttr(weaponType);
        //Debug.Log("WeaponFactory::baseAttr.AssetName = " + baseAttr.AssetName);
        GameObject weaponGO = FactoryManager.AssetFactory.LoadWeapon(baseAttr.AssetName);
        //aSong:文档加载方式解决.将士兵和敌人动态的数据统一放在文件中.加载进来后用Dic来保存Struct
        //将这个工厂改为泛型工厂,然后通过Dic保存 weaponType和对应指定类型的泛型工厂来实例化
        switch (weaponType)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun(baseAttr, weaponGO);
                break;
            case WeaponType.Rifle:
                weapon = new WeaponRifle(baseAttr, weaponGO);
                break;
            case WeaponType.Rocket:
                weapon = new WeaponRocket(baseAttr, weaponGO);
                break;
        }
        return weapon;
        /*
        string assetName = "";
        switch (weaponType)
        {
            case WeaponType.Gun:
                assetName = "WeaponGun";
                break;
            case WeaponType.Rifle:

                assetName = "WeaponRifle";
                break;
            case WeaponType.Rocket:
                assetName = "WeaponRocket";
                break;
        }
        GameObject weaponGO = FactoryManager.AssetFactory.LoadWeapon(assetName);


        switch (weaponType)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun(20, 5, weaponGO);
                break;
            case WeaponType.Rifle:

                weapon = new WeaponRifle(30, 7, weaponGO);

                break;
            case WeaponType.Rocket:
                weapon = new WeaponRocket(40, 8, weaponGO);

                break;
            default:
                break;
        }
        return weapon;
        */
    }
}

