using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class EnemyBuilder : ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, System.Type t, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(character, t, weaponType, spawnPosition, lv)
    {

    }
    public override void AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttr(m_CharacterType);
        m_PrefabName = baseAttr.PrefabName;
        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStategy(), m_LV, baseAttr);
        m_Character.Attr = attr;

       
    }

    public override void AddGameObject()
    {
        //创建角色游戏物体
        //1.加载;2.实例化  
        GameObject characterGO = FactoryManager.AssetFactory.LoadEnemy(m_PrefabName);
        characterGO.transform.position = m_SpawnPosition;
        m_Character.GameObject = characterGO;

        //享元模式优化成员属性
        m_Character.AddSkill(SkillSystem.Instance.NewSkillINstance(1));
        m_Character.AddSkill(SkillSystem.Instance.NewSkillINstance(2));
        //m_Character.AddSkill(SkillSystem.Instance.NewSkillINstance(2));
        //m_Character.AddSkill(SkillSystem.Instance.NewSkillINstance(3));
        //m_Character.AddSkill(SkillSystem.Instance.NewSkillINstance(4));
    }

    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddEnemy(m_Character as IEnemy);
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

