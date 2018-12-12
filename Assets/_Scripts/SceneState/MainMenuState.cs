using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : ISceneState
{

    public MainMenuState(SceneStateController ctrl) : base("02MainMenuScene", ctrl)
    {
    }

    public override void StateStart()
    {
        GameObject.Find("StartGame").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);

    }

    void OnStartButtonClick()
    {
        m_SceneStateCtrl.SetState(new BattleState(m_SceneStateCtrl));
    }
    
}
