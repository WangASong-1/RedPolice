using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景状态类.负责控制各自场景的状态.
/// </summary>
public class ISceneState {
    private string m_SceneName;
    protected SceneStateController m_SceneStateCtrl;

    public string SceneName
    {
        get
        {
            return m_SceneName;
        }
    }

    public ISceneState(string sceneName, SceneStateController stateController) {
        m_SceneName = sceneName;
        m_SceneStateCtrl = stateController;
    }
    
    public virtual void StateStart() { }
    public virtual void StateEnd() { }
    public virtual void StateUpdate() { }
}
