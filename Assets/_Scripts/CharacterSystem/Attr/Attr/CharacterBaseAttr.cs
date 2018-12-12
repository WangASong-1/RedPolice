using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 敌人和战士的享元数据单独类.
/// 若敌人跟战士提出来的属性不同,可以定义接口再继承各自实现
/// </summary>
public class CharacterBaseAttr
{
    protected string m_Name;

    protected int m_MaxHP;

    protected float m_MoveSpeed;

    protected string m_IconSprite;
    protected string m_PrefabName;
    /// <summary>
    /// 暴击率 0~1
    /// </summary>
    protected float m_CritRate;

    public CharacterBaseAttr(string name, int maxHP, float moveSpeed, string iconSprite, string prefabName, float critRate)
    {
        m_Name = name;
        m_MaxHP = maxHP;
        m_MoveSpeed = moveSpeed;
        m_IconSprite = iconSprite;
        m_PrefabName = prefabName;
        m_CritRate = critRate;
    }

    public string Name { get { return m_Name; } }
    public int MaxHP { get { return m_MaxHP; } }
    public float MoveSpeed { get { return m_MoveSpeed; } }
    public string IconName { get { return m_IconSprite; } }
    public string PrefabName { get { return m_PrefabName; } }
    public float CritRate { get { return m_CritRate; } }
}

