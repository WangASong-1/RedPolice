using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 建造者模式：士兵创建builder
/// 这里面m_PrefabName由第一步添加Attr确定,然后再第二步 AddGameObject的时候使用.耦合了.
/// 但是由于是Builder模式,这个类确定后就不需要改了,若新需求来了,只需要重新创建新的builder构造新的士兵
/// 老的留着,应该会用得上
/// </summary>
public class SoldierBuilder : ICharacterBuilder
{
    public SoldierBuilder(ICharacter character, System.Type t, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(character, t, weaponType, spawnPosition, lv)
    {

    }
    public override void AddCharacterAttr()
    {
        /*
        //数值初始化
        string name = "";

        int maxHP = 0;

        float moveSpeed = 0f;

        string iconSprite = "";

        if (m_CharacterType == typeof(SoldierCaptain))
        {
            name = "上尉士兵";
            maxHP = 100;
            moveSpeed = 3f;
            iconSprite = "CaptainIcon";
            m_PrefabName = "Soldier1";
        }
        else if (m_CharacterType == typeof(SoldierSergeant))
        {
            name = "中士士兵";
            maxHP = 90;
            moveSpeed = 3f;
            iconSprite = "SergeantIcon";
            m_PrefabName = "Soldier3";
        }
        else if (m_CharacterType == typeof(SoldierRookie))
        {
            name = "新兵士兵";
            maxHP = 80;
            moveSpeed = 2.5f;
            iconSprite = "RookieIcon";
            m_PrefabName = "Soldier2";
        }
        else
        {
            Debug.LogError("找不到指定的士兵类型　Ｔ=" + m_CharacterType.ToString());
        }
        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStategy(), m_LV, name, maxHP, moveSpeed, iconSprite, m_PrefabName);
        m_Character.Attr = attr;
        */

        //享元模式优化成员属性
        CharacterBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttr(m_CharacterType);
        m_PrefabName = baseAttr.PrefabName;
        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStategy(), m_LV, baseAttr);
        m_Character.Attr = attr;
        m_Character.AddSkill(SkillSystem.Instance.NewSkillINstance(1));
        m_Character.AddSkill(SkillSystem.Instance.NewSkillINstance(2));
        m_Character.AddSkill(SkillSystem.Instance.NewSkillINstance(3));
        m_Character.AddSkill(SkillSystem.Instance.NewSkillINstance(4));
    }

    public override void AddGameObject()
    {
        //创建角色游戏物体
        //1.加载;2.实例化  
        GameObject characterGO = FactoryManager.AssetFactory.LoadSoldier(m_PrefabName);
        characterGO.transform.position = m_SpawnPosition;
        m_Character.GameObject = characterGO;
    }

    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddSoldier(m_Character as ISoldier);
    }

    public override void AddWeapon()
    {
        //添加武器  
        IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(m_weaponType);
        m_Character.Weapon = weapon;
    }

    public override ICharacter GetResult()
    {
        return m_Character;
    }
}

