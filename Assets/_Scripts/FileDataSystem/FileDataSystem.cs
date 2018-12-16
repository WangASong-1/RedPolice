using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using LitJson;
using System.Reflection;
using System.Runtime.InteropServices;

/// <summary>
/// 享元模式里面提取出来的类的属性.
/// Struct是值类型,不能作为享元模式的基础模板
/// </summary>
public struct CharacterBaseAttrModel
{
    public string className;
    public string descName;
    public int maxHp;
    public float moveSpeed;
    public string iconSprite;
    public string prefabName;
    public float critRate;
}

public struct WeaponBaseAttrModel
{
    public string className;
    public string descName;
    public int atk;
    public float atkRange;
    public string prefabName;
}

/// <summary>
/// 因为保存的是游戏中所有的数据(不同场景),所以需要单独的数据结构保存数据.
/// </summary>
public class FileDataSystem : IGameSystem
{
    private Dictionary<string, CharacterBaseAttrModel> mDic_CharacterBaseAttrModel;
    private Dictionary<WeaponType, WeaponBaseAttrModel> mDic_WeaponBaseAttrModel;

    public Dictionary<string, CharacterBaseAttrModel> CharacterBaseAttrModel
    {
        get
        {
            if (mDic_CharacterBaseAttrModel == null)
                InitCharacterBaseAttrModel();
            return mDic_CharacterBaseAttrModel;
        }
    }

    public Dictionary<WeaponType, WeaponBaseAttrModel> WeaponBaseAttrModel
    {
        get
        {
            if (mDic_WeaponBaseAttrModel == null)
                InitWeaponBaseAttrModel();
            return mDic_WeaponBaseAttrModel;
        }
    }

    private void InitWeaponBaseAttrModel()
    {
        WeaponType type = WeaponType.MAX;
        mDic_WeaponBaseAttrModel = new Dictionary<WeaponType, WeaponBaseAttrModel>();
        JsonData jd = aSong_UnityJsonUtil.Read("WeaponBaseAttr", "");
        WeaponBaseAttrModel baseAttr = new WeaponBaseAttrModel();
        for (int i = 0; i < jd.Count; i++)
        {
            Debug.Log(jd[i]["className"].ToString());
            baseAttr.className = jd[i]["className"].ToString();
            baseAttr.descName = jd[i]["className"].ToString();
            baseAttr.atk = int.Parse(jd[i]["atk"].ToString());
            baseAttr.atkRange = float.Parse(jd[i]["atkRange"].ToString());
            baseAttr.prefabName = jd[i]["prefabName"].ToString();

            type = (WeaponType)Enum.Parse(typeof(WeaponType), baseAttr.className.Substring(6));

            mDic_WeaponBaseAttrModel.Add(type, baseAttr);
        }
    }

    private void InitCharacterBaseAttrModel()
    {
        mDic_CharacterBaseAttrModel = new Dictionary<string, CharacterBaseAttrModel>();
        JsonData jd = aSong_UnityJsonUtil.Read("CharacterAttr", "");

        CharacterBaseAttrModel baseAttr = new CharacterBaseAttrModel();
        for (int i = 0; i < jd.Count; i++)
        {
            Debug.Log(jd[i]["className"].ToString());
            baseAttr.className = jd[i]["className"].ToString();
            baseAttr.descName = jd[i]["descName"].ToString();
            baseAttr.maxHp = int.Parse(jd[i]["maxHP"].ToString());
            baseAttr.moveSpeed = float.Parse(jd[i]["moveSpeed"].ToString());
            baseAttr.iconSprite = jd[i]["iconSprite"].ToString();
            baseAttr.prefabName = jd[i]["prefabName"].ToString();
            baseAttr.critRate = float.Parse(jd[i]["critRate"].ToString());
            mDic_CharacterBaseAttrModel.Add(baseAttr.className, baseAttr);
        }

        //foreach (var item in mDic_BaseAttr)
        //{
        //    Debug.Log("111" + item.Value.className);
        //    Type type = typeof(CharacterBaseAttrModel);
        //    var fieldInfos = type.GetFields();
        //    Debug.Log("222 " + fieldInfos.Length);
        //    foreach (var info in fieldInfos)
        //    {
        //        Debug.Log(info.GetValue(mDic_BaseAttr[item.Key]));
        //    }
        //}
    }

    public override void Init()
    {
        base.Init();
        
    }

    public override void Release()
    {
        base.Release();
        mDic_CharacterBaseAttrModel = null;
    }
}

