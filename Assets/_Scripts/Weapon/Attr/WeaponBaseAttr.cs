using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class WeaponBaseAttr
{
    protected string m_Name;
    protected int m_Atk;
    protected float m_AtkRange;
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

