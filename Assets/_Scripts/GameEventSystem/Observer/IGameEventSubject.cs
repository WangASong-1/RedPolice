using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 游戏事件主题类
/// List<IGameEventObserver> 保存订阅者引用,通过 Notify()方法遍历通知订阅者事件触发
/// 在GameEventSystem中利用反射技术动态创建.规定明明规则 事件Type GameEventType+Subject
/// </summary>
public class IGameEventSubject
{
    private List<IGameEventObserver> m_Observers = new List<IGameEventObserver>();

    public void RegisterObserver(IGameEventObserver ob)
    {
        m_Observers.Add(ob);
    }

    public void RemoveObserver(IGameEventObserver ob)
    {
        m_Observers.Remove(ob);
    }

    public virtual void Notify()
    {
        foreach (var item in m_Observers)
        {
            item.Update();
        }
    }

    public virtual void Notify(System.Object paremter)
    {
        foreach (var item in m_Observers)
        {
            item.Update(paremter);
        }
    }
}

