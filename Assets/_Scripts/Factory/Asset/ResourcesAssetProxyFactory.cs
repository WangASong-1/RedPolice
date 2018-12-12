using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 代理模式做新的资源加载方法的测试
/// 我看着咋那么像装饰模式
/// 这里做的是流程控制,但其实也是增强功能.我分不出
/// </summary>
public class ResourcesAssetProxyFactory : IAssetFactory
{
    private ResourcesAssetFactory m_ResourcesAssetFactory = new ResourcesAssetFactory();

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
            GameObject go = m_ResourcesAssetFactory.LoadEffect(name);
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
            GameObject go = m_ResourcesAssetFactory.LoadEnemy(name);
            m_Enemys.Add(name, go);
            go.transform.position = Vector3.up * -2f;
            return GameObject.Instantiate(go);
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
            GameObject go = m_ResourcesAssetFactory.LoadSoldier(name);
            m_Soldiers.Add(name, go);
            go.transform.position = Vector3.up * -2f;
            return GameObject.Instantiate(go);
            //return go;
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
            GameObject go = m_ResourcesAssetFactory.LoadWeapon(name);
            m_Weapons.Add(name,go);
            go.transform.position = Vector3.up * -2f;
            return GameObject.Instantiate(go);
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
            Sprite go = m_ResourcesAssetFactory.LoadSprite(name);
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
            AudioClip go = m_ResourcesAssetFactory.LoadAudioClip(name);
            m_AudioClips.Add(name, go);
            return go;
        }
    }
}

