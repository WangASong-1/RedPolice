using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public abstract class ICharacterBuilder
{
    protected ICharacter m_Character;
    protected string m_CharacterType;
    protected WeaponType m_weaponType;
    protected Vector3 m_SpawnPosition;
    protected int m_LV;
    protected string m_PrefabName;

    public ICharacterBuilder(ICharacter character, System.Type t, WeaponType weaponType, Vector3 spawnPosition, int lv)
    {
        m_Character = character;
        m_CharacterType = t.ToString();
        m_weaponType = weaponType;
        m_SpawnPosition = spawnPosition;
        m_LV = lv;
    }

    public abstract void AddCharacterAttr();
    public abstract void AddWeapon();
    public abstract void AddGameObject();
    public abstract void AddInCharacterSystem();
    public abstract ICharacter GetResult();
}

