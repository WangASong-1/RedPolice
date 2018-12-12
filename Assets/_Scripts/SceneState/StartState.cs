using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartState : ISceneState
{

    public StartState(SceneStateController ctrl) : base("01StartScene", ctrl)
    {
    }

    private Image mLogo;
    private float m_FadeSpeed = 2f;
    private float m_WaitTime = 2f;
    public override void StateStart()
    {
        mLogo = GameObject.Find("Logo").GetComponent<Image>();
        mLogo.color = Color.clear;
    }
    public override void StateUpdate()
    {
        mLogo.color = Color.Lerp(mLogo.color, Color.white, m_FadeSpeed * Time.deltaTime);
        m_WaitTime -= Time.deltaTime;
        if(m_WaitTime < 0)
        {
            m_SceneStateCtrl.SetState(new MainMenuState(m_SceneStateCtrl));
        }
    }

    public override void StateEnd()
    {
        base.StateEnd();
    }
}
