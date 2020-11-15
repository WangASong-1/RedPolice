using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


public class ResourcesAssetFactory : IAssetFactory
{
    public const string SoldierPath = "Characters/Soldier";
    public const string EnemyPath = "Characters/Enemy";
    public const string WeaponPath = "Weapons";
    public const string EffectPath = "Effects";
    public const string AudioPath = "Audios";
    public const string SpritePath = "Sprites";

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(Path.Combine( EffectPath ,name));

    }

    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(Path.Combine( EnemyPath,name));
    }

    public GameObject LoadSoldier(string name)
    {
        return InstantiateGameObject(Path.Combine(SoldierPath, name));
    }

    public GameObject LoadWeapon(string name)
    {
        return InstantiateGameObject(Path.Combine(WeaponPath, name));
    }

    public Sprite LoadSprite(string name)
    {
        return Resources.Load<Sprite>(Path.Combine(SpritePath, name));
        //return (Sprite)LoadAsset(Path.Combine(SpritePath, name));
    }

    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load<AudioClip>(Path.Combine(AudioPath, name));
        //return (AudioClip)LoadAsset(Path.Combine(AudioPath, name));
    }



    private GameObject InstantiateGameObject(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if(o == null)
        {
            Debug.LogError("无法从 path [" + path + "] 加载资源");
        }
        return GameObject.Instantiate(o) as GameObject;
    }

    public UnityEngine.Object LoadAsset(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("无法从 path [" + path.ToString() + "] 加载资源");
        }
        return o;
    }
}

