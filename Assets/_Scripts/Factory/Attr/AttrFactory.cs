using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Reflection;

/// <summary>
/// 享元模式,将共有且不变的属性提出来
/// 所有同一系列,同一种类的士兵敌人使用同一种属性
/// </summary>
public class AttrFactory : IAttrFactory
{
    private Dictionary<string, CharacterBaseAttr> mDic_CharacterBaseAttr;
    private Dictionary<WeaponType, WeaponBaseAttr> mDic_WeaponBaseAttr;
    public AttrFactory()
    {
        InitCharacterBaseAttr();
        InitWeaponBaseAttr();
    }

    private void InitCharacterBaseAttr()
    {
        Dictionary<string, CharacterBaseAttrModel> baseAttr = GameFacade.Instance.CharacterBaseAttr1Model;
        mDic_CharacterBaseAttr = new Dictionary<string, CharacterBaseAttr>();

        foreach (var item in baseAttr)
        {
            mDic_CharacterBaseAttr.Add(item.Value.className, 
                new CharacterBaseAttr(item.Value.descName, item.Value.maxHp, item.Value.moveSpeed, 
                                    item.Value.iconSprite, item.Value.prefabName, item.Value.critRate));
        }
    }

    private void InitWeaponBaseAttr()
    {
        //mDic_WeaponBaseAttr = new Dictionary<WeaponType, WeaponBaseAttr>
        //{
        //    { WeaponType.Gun, new WeaponBaseAttr("手枪",20,5,"WeaponGun")},
        //    { WeaponType.Rifle, new WeaponBaseAttr("来福",30,7,"WeaponRifle")},
        //    { WeaponType.Rocket, new WeaponBaseAttr("火箭",40,8,"WeaponRocket")}
        //};

        var baseAttr = GameFacade.Instance.WeaponBaseAttrModel;
        mDic_WeaponBaseAttr = new Dictionary<WeaponType, WeaponBaseAttr>();

        foreach (var item in baseAttr)
        {
            mDic_WeaponBaseAttr.Add(item.Key,
                new WeaponBaseAttr(item.Value.descName, item.Value.atk, item.Value.atkRange, item.Value.prefabName));
        }
    }
    public CharacterBaseAttr GetCharacterBaseAttr(string str)
    {
        if (!mDic_CharacterBaseAttr.ContainsKey(str))
        {
            Debug.LogError("AttrFactory::无法找到指定类型的属性 ---" + str);
        }
        return mDic_CharacterBaseAttr[str];
    }

    public WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType)
    {
        if (!mDic_WeaponBaseAttr.ContainsKey(weaponType))
        {
            Debug.LogError("AttrFactory::无法找到指定类型的武器 ---" + weaponType.ToString());
        }

        return mDic_WeaponBaseAttr[weaponType];
    }
}

