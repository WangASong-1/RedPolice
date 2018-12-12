
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Reflection;

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
/// 利用反射动态创建 Subject. 
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

    //添加Subject放在Get方法里根据需要创建,若是放在Init里的话会跟注册事件放在Init里耦合
    //因为事件Event的创建比较散,所以无法确定在哪个Init中,所以为了避免耦合这里使用反射技术规避Switch
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
            //aSong:这个可以使用反射,因为仅需要一次性
            if(eventType != GameEventType.Null)
                m_GameEvents.Add(eventType, Assembly.GetExecutingAssembly().CreateInstance(eventType.ToString() + "Subject") as IGameEventSubject);
                //m_GameEvents.Add(eventType, Activator.CreateInstance( Type.GetType(eventType.ToString()+"Subject")) as IGameEventSubject);
                /*
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
                */
                //return null;
        }
        return m_GameEvents[eventType];
    }
}