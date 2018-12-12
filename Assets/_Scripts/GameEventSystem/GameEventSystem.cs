
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
/// �¼�����ϵͳ
/// �۲���ģʽ��Subject��List���� Observer
///             ���Subject���Observer,Subject����Observer��Ҫ�Ĳ�����������,Ȼ����Notify����Observer
/// ����ʿ���������������¹ؿ��¼�����
/// </summary>
public class GameEventSystem : IGameSystem {
    /// <summary>
    /// �ֵ䱣���¼����ͺ�����,��������List���涩����
    /// </summary>
    private Dictionary<GameEventType, IGameEventSubject> m_GameEvents = new Dictionary<GameEventType, IGameEventSubject>();

    public override void Init()
    {
        base.Init();
        //InitGameEvents();
    }

    //���Subject����Get������,����Init��Ļ����ע���¼�����Init�����
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
    /// ������Ϣ
    /// </summary>
    /// <param name="eventType"> ��Ϣ����</param>
    public void NotyfySubject(GameEventType eventType)
    {
        IGameEventSubject sub = GetGameEventSub(eventType);
        if (sub == null) return;
        sub.Notify();
    }

    /// <summary>
    /// ������Ϣ,������
    /// </summary>
    /// <param name="eventType">��Ϣ����</param>
    /// <param name="paremter">��Ҫ���ݵĲ���(Object����ת��,����Struct����Class)</param>
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
                    Debug.LogError("û�ж�Ӧ�¼����� " + eventType + "������");
                    return null;
            }
            //return null;
        }
        return m_GameEvents[eventType];
    }
}