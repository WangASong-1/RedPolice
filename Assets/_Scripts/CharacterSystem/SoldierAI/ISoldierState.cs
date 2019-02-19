using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 士兵转换条件
/// </summary>
public enum SoldierTransition
{
    NullTransition =0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

/// <summary>
/// 士兵当前状态ID
/// </summary>
public enum SoldierStateID
{
    NullState= 0,
    Idle,
    Chase,
    Attack
}

/// <summary>
/// 士兵的状态抽象类,定义了该士兵当前状态下的整套行为的处理
/// </summary>
public abstract class ISoldierState
{
    /// <summary>
    /// 通过字典保存所拥有的转换条件以及当前转换条件下需要转换到的状态ID
    /// </summary>
    protected Dictionary<SoldierTransition, SoldierStateID> m_Map = new Dictionary<SoldierTransition, SoldierStateID>();
    protected SoldierStateID m_StateID;
    protected ICharacter m_Charater;
    protected SoldierFSMSystem m_FSM;

    public ISoldierState(SoldierFSMSystem fsm, ICharacter charater)
    {
        m_FSM = fsm;
        m_Charater = charater;
    }

    public SoldierStateID StateID { get { return m_StateID; } }

    public void AddTransition(SoldierTransition trans, SoldierStateID stateID)
    {
        if(trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("SoldierState Error: trans 不能为空"); return;
        }
        if (stateID == SoldierStateID.NullState)
        {
            Debug.LogError("SoldierState Error: stateID 不能为空"); return;
        }
        if (m_Map.ContainsKey(trans))
        {
            Debug.LogError("SoldierState Error: "+trans +" 已经添加上了"); return;
        }
        m_Map.Add(trans, stateID);
    }

    public void DeleteTransition(SoldierTransition transition)
    {
        if (!m_Map.ContainsKey(transition))
        {
            Debug.LogError("删除转换条件失败,不存在该条件 : " + transition.ToString());return;
        }
        m_Map.Remove(transition);
    }

    /// <summary>
    /// 根据指定的转换条件获取状态ID
    /// </summary>
    /// <param name="transition"></param>
    /// <returns></returns>
    public SoldierStateID GetOutPutState(SoldierTransition transition)
    {
        if (!m_Map.ContainsKey(transition))
        {
            Debug.LogError("获取转换条件失败,不存在该条件 : " + transition.ToString());
            return SoldierStateID.NullState;
        }
        return m_Map[transition];
    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    /// <summary>
    /// 行为动机
    /// </summary>
    public abstract void Reason(List<ICharacter> targets);
    /// <summary>
    /// 表现
    /// </summary>
    public abstract void Act(List<ICharacter> targets);
}

