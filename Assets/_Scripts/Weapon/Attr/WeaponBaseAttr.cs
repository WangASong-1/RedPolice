using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 享元模式共享数据
/// </summary>
public class WeaponBaseAttr
{
    /// <summary>
    /// DescName
    /// </summary>
    protected string m_Name;
    /// <summary>
    /// 攻击力
    /// </summary>
    protected int m_Atk;

    /// <summary>
    /// 攻击范围
    /// </summary>
    protected float m_AtkRange;

    /// <summary>
    /// 资源名称
    /// </summary>
    protected string m_AssetName;

    public WeaponBaseAttr(string name,int atk, float atkRange,string assetName)
    {
        m_Name = name;
        m_Atk = atk;
        m_AtkRange = atkRange;
        m_AssetName = assetName;
    }

    public string Name { get { return m_Name; } }
    public int Atk { get { return m_Atk; } }
    public float AtkRange { get { return m_AtkRange; } }
    public string AssetName { get { return m_AssetName; } }
}

