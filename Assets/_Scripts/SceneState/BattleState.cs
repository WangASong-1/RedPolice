using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 战斗场景状态
/// 通过外观模式,将自己的三个接口状态包给GameFacade类去组合多个子系统接口来实现.自己单一负责战斗状态的切换
/// </summary>
public class BattleState : ISceneState
{
    public BattleState(SceneStateController ctrl):base("03BattleScene", ctrl)
    {

    }

    
    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }
    public override void StateUpdate()
    {
        if (GameFacade.Instance.IsGameOver)
        {
            m_SceneStateCtrl.SetState(new MainMenuState(m_SceneStateCtrl));
        }
        GameFacade.Instance.Update();
    }

    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }
}
