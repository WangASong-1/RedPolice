using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 工厂管理类.所有的工厂放在这里
/// </summary>
public static class FactoryManager
{
    private static IAssetFactory m_AssetFactory = null;
    private static ICharacterFactory m_SoldierFactory = null;
    private static ICharacterFactory m_EnemyFactory = null;
    private static IWeaponFactory m_WeaponFactory = null;
    private static IAttrFactory m_AttrFactory = null;

    public static IAttrFactory AttrFactory
    {
        get
        {
            if (m_AttrFactory == null)
            {
                m_AttrFactory = new AttrFactory();
            }
            return m_AttrFactory;
        }
    }

    /// <summary>
    /// 资源加载工厂,这里需要根据配置文件确定具体使用哪个资源加载工厂
    /// 或者通过添加接口,三者加载方式都使用
    /// </summary>
    public static IAssetFactory AssetFactory
    {
        get
        {
            if(m_AssetFactory == null)
            {
                //m_AssetFactory = new ResourcesAssetFactory();
                m_AssetFactory = new ResourcesAssetProxyFactory();
            }
            return m_AssetFactory;
        }
    }
    public static ICharacterFactory SoldierFactory
    {
        get
        {
            if (m_SoldierFactory == null)
            {
                m_SoldierFactory = new SoldierFactory();
            }
            return m_SoldierFactory;
        }
    }
    public static ICharacterFactory EnemyFactory
    {
        get
        {
            if (m_EnemyFactory == null)
            {
                m_EnemyFactory = new EnemyFactory();
            }
            return m_EnemyFactory;
        }
    }
    public static IWeaponFactory WeaponFactory
    {
        get
        {
            if (m_WeaponFactory == null)
            {
                m_WeaponFactory = new WeaponFactory();
            }
            return m_WeaponFactory;
        }
    }
}

