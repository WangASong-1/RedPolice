using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 责任链模式
/// </summary>
public abstract class IStageHandler
{
    protected int m_Lv;
    protected IStageHandler m_NextHandler;
    protected StageSystem m_StageSystem;
    protected int m_CountToFinished;

    public IStageHandler(StageSystem stageSystem,int lv, int countToFinished)
    {
        m_StageSystem = stageSystem;
        m_Lv = lv;
        m_CountToFinished = countToFinished;
    }

    /// <summary>
    /// 定制责任链
    /// </summary>
    /// <param name="handler"></param>
    /// <returns></returns>
    public IStageHandler SetNextHandler(IStageHandler handler)
    {
        m_NextHandler = handler;
        return m_NextHandler;
    }

    /// <summary>
    /// 责任链模式核心思想,当前节点完成不了,就遍历下一个节点去解决
    /// </summary>
    /// <param name="level"></param>
    public void Handle(int level)
    {
        if(level == m_Lv)
        {
            UpdateStage();
            CheckIsFinished();
        }
        else
        {
            if(m_NextHandler!=null)
                m_NextHandler.Handle(level);
        }
    }

    private void CheckIsFinished()
    {
        if (m_StageSystem.GetCountOfEnemyKilled() >= m_CountToFinished)
        {
            m_StageSystem.EnterNextStage();
        }
    }

    protected virtual void UpdateStage() { }
}

