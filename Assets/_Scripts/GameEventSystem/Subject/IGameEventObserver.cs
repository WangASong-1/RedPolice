using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察者模式：Observer
/// 使用Update响应 Subject的Notify
/// </summary>
public abstract class IGameEventObserver
{
    /// <summary>
    /// 响应 Subject的Notify
    /// </summary>
    public abstract void Update();
    public abstract void Update(System.Object paremter);
    public abstract void SetSubject(IGameEventSubject sub);
   
}

