using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 享元模式,将共有且不变的属性提出来
/// 所有同一系列,同一种类的士兵敌人使用同一种属性
/// </summary>
public class AttrFactory : IAttrFactory
{
    private Dictionary<Type, CharacterBaseAttr> mDic_CharacterBaseAttr;
    private Dictionary<WeaponType, WeaponBaseAttr> mDic_WeaponBaseAttr;
    public AttrFactory()
    {
        InitCharacterBaseAttr();
        InitWeaponBaseAttr();
    }

    private void InitCharacterBaseAttr()
    {
        mDic_CharacterBaseAttr = new Dictionary<Type, CharacterBaseAttr>
        {
            { typeof(SoldierRookie), new CharacterBaseAttr("新兵士兵", 80, 2.5f, "RookieIcon", "Soldier2", 0) },
            { typeof(SoldierSergeant), new CharacterBaseAttr("中士士兵", 90, 3f, "SergeantIcon", "Soldier3", 0) },
            { typeof(SoldierCaptain), new CharacterBaseAttr("上尉士兵", 100, 3f, "CaptainIcon", "Soldier1", 0) },
            { typeof(EnemyElf), new CharacterBaseAttr("小精灵", 100, 3f, "ElfIcon", "Enemy1", 0.2f) },
            { typeof(EnemyOgre), new CharacterBaseAttr("食人魔", 120, 4f, "OgreIcon", "Enemy2", 0.3f) },
            { typeof(EnemyTroll), new CharacterBaseAttr("巨魔", 200, 1f, "TrollIcon", "Enemy3", 0.4f) }
        };

    }

    private void InitWeaponBaseAttr()
    {
        mDic_WeaponBaseAttr = new Dictionary<WeaponType, WeaponBaseAttr>
        {
            { WeaponType.Gun, new WeaponBaseAttr("手枪",20,5,"WeaponGun")},
            { WeaponType.Rifle, new WeaponBaseAttr("来福",30,7,"WeaponRifle")},
            { WeaponType.Rocket, new WeaponBaseAttr("火箭",40,8,"WeaponRocket")}
        };
    }
    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        if (!mDic_CharacterBaseAttr.ContainsKey(t))
        {
            Debug.LogError("AttrFactory::无法找到指定类型的属性 ---" + t.ToString());
        }
        return mDic_CharacterBaseAttr[t];
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

