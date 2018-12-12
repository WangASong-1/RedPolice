
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

/// <summary>
/// 士兵属性UI,这个没做
/// </summary>
public class SoldierInfoUI : IBaseUI {
    private Image m_SoldierIcon;
    private Image m_SoldierName;
    private Text m_HPText;
    private Slider m_HPSlider;
    private Text m_Lv;
    private Text m_Atk;
    private Text m_AtkRange;
    private Text m_MoveSpeed;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        m_RootUI = canvas.FindChildTraversing("SoldierInfoUI");

        m_SoldierIcon = Utilitys.FindChild<Image>(m_RootUI, "SoldierIcon");
        m_SoldierName = Utilitys.FindChild<Image>(m_RootUI, "SoldierName");
        m_HPText = Utilitys.FindChild<Text>(m_RootUI, "HPNumber");
        m_HPSlider = Utilitys.FindChild<Slider>(m_RootUI, "HPSlider");
        m_Lv = Utilitys.FindChild<Text>(m_RootUI, "Level");
        m_Atk = Utilitys.FindChild<Text>(m_RootUI, "Atk");
        m_AtkRange = Utilitys.FindChild<Text>(m_RootUI, "AtkRange");
        m_MoveSpeed = Utilitys.FindChild<Text>(m_RootUI, "MoveSpeed");

        Hide();
    }

}