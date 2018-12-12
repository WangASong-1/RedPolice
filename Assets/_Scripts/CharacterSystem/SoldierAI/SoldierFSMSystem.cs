﻿using System.Collections.Generic;
using UnityEngine;

//士兵 持有,负责管理士兵状态的切换
public class SoldierFSMSystem
{
    /// <summary>
    /// 持有的状态链表
    /// </summary>
    private List<ISoldierState> mLst_States = new List<ISoldierState>();
    /// <summary>
    /// 当前状态
    /// </summary>
    private ISoldierState m_CurrentState;
    
    public ISoldierState CurrentState { get { return m_CurrentState; } }

    public void AddState(params ISoldierState[] states)
    {
        foreach(var s in states)
        {
            AddState(s);
        }
    }
    /// <summary>
    /// 添加状态到状态链表中
    /// </summary>
    /// <param name="state"></param>
    public void AddState(ISoldierState state)
    {
        if(state == null)
        {
            Debug.LogError("状态为空,不添加");return;
        }

        if(mLst_States.Count == 0)
        {
            mLst_States.Add(state);
            m_CurrentState = state;
            return;
        }
        foreach(ISoldierState s in mLst_States)
        {
            if(s.StateID == state.StateID)
            {
                Debug.LogError("要添加的状态ID已经存在 ID= " + s.StateID.ToString());
                return;
            }
        }

        mLst_States.Add(state);
    }

    /// <summary>
    /// 删除状态
    /// </summary>
    /// <param name="stateID"></param>
    public void DeleteState(SoldierStateID stateID)
    {
        if (stateID == SoldierStateID.NullState)
        {
            Debug.LogError("状态为空,不删除 " + stateID); return;
        }
        
        foreach(var s in mLst_States)
        {
            if(s.StateID == stateID)
            {
                mLst_States.Remove(s);
                return;
            }
        }

        Debug.LogError("要删除的ID不存在于集合中 id = " + stateID);
    }

    /// <summary>
    /// 执行转换,切换到对应条件的状态类
    /// </summary>
    /// <param name="transition"></param>
    public void PerformTransition(SoldierTransition transition)
    {
        if(transition == SoldierTransition.NullTransition)
        {
            Debug.LogError("要转换的条件为空 " + transition);return;
        }
        SoldierStateID nextStateID = m_CurrentState.GetOutPutState(transition);
        if(nextStateID == SoldierStateID.NullState)
        {
            Debug.LogError("当前状态 [" + m_CurrentState.StateID+"]" +" 转换条件 [" + transition + "] 没有对应的转换状态");
            return;
        }
        foreach(var s in mLst_States)
        {
            if(s.StateID == nextStateID)
            {
                m_CurrentState.DoBeforeLeaving();
                m_CurrentState = s;
                m_CurrentState.DoBeforeEntering();
                return;
            }
        }
    }
}
