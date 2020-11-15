using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

/// <summary>
/// 代理模式做新的资源加载方法的测试. 测试代码，测试新的内容的可行性(同接口，方便接入).
/// 我看着咋那么像装饰模式
/// 这里做的是流程控制,但其实也是增强功能.我分不出
/// </summary>
public class ResourcesAssetProxyFactory : IAssetFactory
{
    private ResourcesAssetFactory mAssetFactory = new ResourcesAssetFactory();

    private Dictionary<string, GameObject> m_Soldiers = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> m_Enemys = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> m_Effects = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> m_Weapons = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> m_AudioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, Sprite> m_Sprites = new Dictionary<string, Sprite>();

   

    public GameObject LoadEffect(string name)
    {
        if (m_Effects.ContainsKey(name))
        {
            return GameObject.Instantiate(m_Effects[name]);

        }
        else
        {
            GameObject go = mAssetFactory.LoadEffect(name);
            m_Effects.Add(name, go);
            go.transform.position = Vector3.up * -2f;
            return GameObject.Instantiate(go);
        }
    }

    public GameObject LoadEnemy(string name)
    {
        if (m_Enemys.ContainsKey(name))
        {
            return GameObject.Instantiate( m_Enemys[name]);
        }
        else
        {
            GameObject asset = mAssetFactory.LoadAsset(Path.Combine(ResourcesAssetFactory.EnemyPath ,name)) as GameObject;
            m_Enemys.Add(name, asset);
            asset.transform.position = Vector3.up * -2f;
            return GameObject.Instantiate(asset);
        }
    }

    /// <summary>
    /// dic 保存的应该是load进来的,而不是实例化的.所以这里优化还不如直接重写
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject LoadSoldier(string name)
    {
        if (m_Soldiers.ContainsKey(name))
        {
            return GameObject.Instantiate(m_Soldiers[name]);
        }
        else
        {
            GameObject asset = mAssetFactory.LoadAsset(Path.Combine(ResourcesAssetFactory.SoldierPath , name)) as GameObject;
            m_Soldiers.Add(name, asset);
            asset.transform.position = Vector3.up * -2f;
            return GameObject.Instantiate(asset);
        }
    }


    public GameObject LoadWeapon(string name)
    {
        if (m_Weapons.ContainsKey(name))
        {
            return GameObject.Instantiate(m_Weapons[name]);

        }
        else
        {
            GameObject asset = mAssetFactory.LoadAsset(Path.Combine(ResourcesAssetFactory.WeaponPath , name)) as GameObject;
            m_Weapons.Add(name, asset);
            asset.transform.position = Vector3.up * -2f;
            return GameObject.Instantiate(asset);
        }
    }


    public Sprite LoadSprite(string name)
    {
        if (m_Sprites.ContainsKey(name))
        {
            return m_Sprites[name];
        }
        else
        {
            Sprite go = mAssetFactory.LoadSprite(name);
            m_Sprites.Add(name, go);
            return go;
        }
    }

    public AudioClip LoadAudioClip(string name)
    {
        if (m_AudioClips.ContainsKey(name))
        {
            return m_AudioClips[name];
        }
        else
        {
            AudioClip go = mAssetFactory.LoadAudioClip(name);
            m_AudioClips.Add(name, go);
            return go;
        }
    }
}

