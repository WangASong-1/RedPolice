using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 使用状态模式控制场景的切换.
/// 该类主要负责控制状态(场景)切换的准备工作以及执行切换
/// </summary>
public class SceneStateController
{
    public ISceneState m_SceneState;
    private AsyncOperation m_AO;
    private bool m_IsRunState = false;

    public void SetState(ISceneState state, bool isLoadScene = true)
    {
        if (m_SceneState != null)
        {
            m_SceneState.StateEnd();
        }
        m_SceneState = state;

        if (isLoadScene)
        {
            m_AO = SceneManager.LoadSceneAsync(m_SceneState.SceneName);
            m_IsRunState = false;
        }
        else{
            m_SceneState.StateStart();
            m_IsRunState = true;
        }

    }

    public void UpdateState()
    {
        //场景加载ing，直接返回
        if (m_AO != null && !m_AO.isDone) return;

        //场景加载完毕,直接切换场景
        if(m_AO!=null && m_AO.isDone && !m_IsRunState)
        {
            m_SceneState.StateStart();
            m_IsRunState = true;
        }

        //场景运行中
        if (m_SceneState != null)
        {
            m_SceneState.StateUpdate();
        }
    }
}
