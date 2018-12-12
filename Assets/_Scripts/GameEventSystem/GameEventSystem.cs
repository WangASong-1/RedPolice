
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public enum GameEventType
{
    Null,
    EnemyKilled,
    SoldierKilled,
    NewStage
}

/// <summary>
/// 事件管理系统
/// 观察者模式：Subject用List保存 Observer
///             多个Subject多个Observer,Subject负责将Observer需要的参数保存下来,然后再Notify告诉Observer
/// 负责：士兵、敌人死亡和新关卡事件处理
/// </summary>
public class GameEventSystem : IGameSystem {
    /// <summary>
    /// 字典保存事件类型和主题,主题中用List保存订阅者
    /// </summary>
    private Dictionary<GameEventType, IGameEventSubject> m_GameEvents = new Dictionary<GameEventType, IGameEventSubject>();

    public override void Init()
    {
        base.Init();
        //InitGameEvents();
    }

    //添加Subject放在Get方法里,放在Init里的话会跟注册事件放在Init里耦合
    private void InitGameEvents()
    {
        m_GameEvents.Add(GameEventType.EnemyKilled, new EnemyKilledSubject());
        m_GameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
        m_GameEvents.Add(GameEventType.NewStage, new NewStageSubject());
    }

    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEventSub(eventType);
        if (sub == null) return;
        sub.RegisterObserver(observer);
        observer.SetSubject(sub);
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEventSub(eventType);
        if (sub == null) return;
        sub.RemoveObserver(observer);
        observer.SetSubject(null);
    }

    /// <summary>
    /// 发布消息
    /// </summary>
    /// <param name="eventType"> 消息类型</param>
    public void NotyfySubject(GameEventType eventType)
    {
        IGameEventSubject sub = GetGameEventSub(eventType);
        if (sub == null) return;
        sub.Notify();
    }

    /// <summary>
    /// 发布消息,带参数
    /// </summary>
    /// <param name="eventType">消息类型</param>
    /// <param name="paremter">需要传递的参数(Object方便转换,比如Struct或者Class)</param>
    public void NotyfySubject(GameEventType eventType, System.Object paremter)
    {
        IGameEventSubject sub = GetGameEventSub(eventType);
        if (sub == null) return;
        sub.Notify(paremter);
    }

    private IGameEventSubject GetGameEventSub(GameEventType eventType)
    {
        if (!m_GameEvents.ContainsKey(eventType))
        {
            switch (eventType)
            {
                case GameEventType.EnemyKilled:
                    m_GameEvents.Add(GameEventType.EnemyKilled, new EnemyKilledSubject());
                    break;
                case GameEventType.SoldierKilled:
                        m_GameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
                    break;
                case GameEventType.NewStage:
                    m_GameEvents.Add(GameEventType.NewStage, new NewStageSubject());
                    break;
                default:
                    Debug.LogError("没有对应事件类型 " + eventType + "主题类");
                    return null;
            }
            //return null;
        }
        return m_GameEvents[eventType];
    }
}