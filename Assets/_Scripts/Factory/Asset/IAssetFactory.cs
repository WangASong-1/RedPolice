using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 抽象工厂模式,加载一类的资源
/// </summary>
public interface IAssetFactory
{
    GameObject LoadSoldier(string name);
    GameObject LoadEnemy(string name);
    GameObject LoadWeapon(string name);
    GameObject LoadEffect(string name);
    AudioClip LoadAudioClip(string name);
    Sprite LoadSprite(string name);

}

