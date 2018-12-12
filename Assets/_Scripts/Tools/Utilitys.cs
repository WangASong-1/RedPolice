using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public static class Utilitys
{ 
    public static bool IsCountNull<T>(this List<T> lst)
    {
        if(lst!=null && lst.Count > 0)
        {
            return false;
        }
        return true;
    }

    public static GameObject FindChildTraversing(this GameObject parent,string childName)
    {
        Transform[] children = parent.transform.GetComponentsInChildren<Transform>();
        bool isFinded = false;
        Transform child = null;
        foreach(Transform t in children)
        {
            if(t.name == childName)
            {
                if (isFinded)
                {
                    Debug.LogError("在游戏体 [" + parent.name + "] 中存在多个名叫[" + childName + "] 的子物体");
                }
                isFinded = true;
                child = t;
            }
        }
        if(isFinded )
            return child.gameObject;
        else
        {
            Debug.LogError("在游戏体 [" + parent.name + "] 中不存在名叫[" + childName + "] 的子物体");
            return null;
        }

    }

    public static T FindChild<T>(GameObject parent, string childName)
    {
        GameObject uiGO = parent.FindChildTraversing(childName);
        if(uiGO !=null)
            return uiGO.GetComponent<T>();
        else
        {
            return default(T);
        }
    }

    /// <summary>
    /// 将指定的 child 放置到parent下去,并Transform的local属性置0
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="child"></param>
    public static void Attach(GameObject parent, GameObject child)
    {
        child.transform.parent = parent.transform;
        child.transform.localPosition = Vector3.zero;
        child.transform.localEulerAngles = Vector3.zero;
        child.transform.localEulerAngles = Vector3.zero;
    }
}

