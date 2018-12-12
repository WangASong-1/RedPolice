using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum EnemyTransition
{
    NullTransition = 0,
    CanAttack,
    LostSoldier
}

public enum EnemyStateID
{
    NullState,
    Chase,
    Attack
}

public abstract class IEnemyState
{
    /// <summary>
    /// 通过字典保存所拥有的转换条件以及当前转换条件下需要转换到的状态ID
    /// </summary>
    protected Dictionary<EnemyTransition, EnemyStateID> m_Map = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID m_StateID;
    protected ICharacter m_Charater;
    protected EnemyFSMSystem m_FSM;

    public IEnemyState(EnemyFSMSystem fsm, ICharacter charater)
    {
        m_FSM = fsm;
        m_Charater = charater;
    }

    public EnemyStateID StateID { get { return m_StateID; } }

    public void AddTransition(EnemyTransition trans, EnemyStateID stateID)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("EnemyState Error: trans 不能为空"); return;
        }
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("EnemyState Error: stateID 不能为空"); return;
        }
        if (m_Map.ContainsKey(trans))
        {
            Debug.LogError("EnemyState Error: " + trans + " 已经添加上了"); return;
        }
        m_Map.Add(trans, stateID);
    }

    public void DeleteTransition(EnemyTransition transition)
    {
        if (!m_Map.ContainsKey(transition))
        {
            Debug.LogError("删除转换条件失败,不存在该条件 : " + transition.ToString()); return;
        }
        m_Map.Remove(transition);
    }

    /// <summary>
    /// 根据指定的转换条件获取状态ID
    /// </summary>
    /// <param name="transition"></param>
    /// <returns></returns>
    public EnemyStateID GetOutPutState(EnemyTransition transition)
    {
        if (!m_Map.ContainsKey(transition))
        {
            Debug.LogError("获取转换条件失败,不存在该条件 : " + transition.ToString());
            return EnemyStateID.NullState;
        }
        return m_Map[transition];
    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    /// <summary>
    /// 行为动机,切换条件判断
    /// </summary>
    public abstract void Reason(List<ICharacter> targets);
    /// <summary>
    /// 表现
    /// </summary>
    public abstract void Act(List<ICharacter> targets);
}

