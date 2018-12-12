
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

/// <summary>
/// ”Œœ∑‘›Õ£Panel
/// </summary>
public class GamePauseUI : IBaseUI {
    private Text m_CurrentStageLv;
    private Button m_ContinueBtn;
    private Button m_BackMenuBtn;

    public GamePauseUI() {
    }

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        m_RootUI = canvas.FindChildTraversing("GamePauseUI");
        m_CurrentStageLv = Utilitys.FindChild<Text>(m_RootUI, "CurrentStageLv");
        m_BackMenuBtn = Utilitys.FindChild<Button>(m_RootUI, "BackMenuBtn");
        m_ContinueBtn = Utilitys.FindChild<Button>(m_RootUI, "ContinueBtn");

        Hide();
    }

}