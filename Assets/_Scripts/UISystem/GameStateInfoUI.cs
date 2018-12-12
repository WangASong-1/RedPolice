
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

/// <summary>
/// 状态Panel
/// </summary>
public class GameStateInfoUI : IBaseUI {
    private List<GameObject> m_Hearts;
    private Text m_SoldierCount;
    private Text m_EnemyCount;
    private Text m_CurrentStage;
    private Button m_PauseBtn;
    private GameObject m_GameOverUI;
    private Button m_BackMenuBtn;
    private Text m_Message;
    private Slider m_EnergySlider;
    private Text m_EnergyText;

    private float m_MsgTimer = 0f;
    private float m_MsgTime = 2f;
    private AliveCountVisitor m_AliveCountVisitor = new AliveCountVisitor();


    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        m_RootUI = canvas.FindChildTraversing("GameStateUI");

        m_Hearts = new List<GameObject>();
        GameObject heart1 = m_RootUI.FindChildTraversing("Heart1");
        GameObject heart2 = m_RootUI.FindChildTraversing("Heart2");
        GameObject heart3 = m_RootUI.FindChildTraversing("Heart3");
        m_Hearts.Add(heart1);
        m_Hearts.Add(heart2);
        m_Hearts.Add(heart3);

        m_SoldierCount = Utilitys.FindChild<Text>(m_RootUI, "SoldierCount");
        m_EnemyCount = Utilitys.FindChild<Text>(m_RootUI, "EnemyCount");
        m_CurrentStage = Utilitys.FindChild<Text>(m_RootUI, "StageCount");
        m_PauseBtn = Utilitys.FindChild<Button>(m_RootUI, "PauseBtn");
        m_GameOverUI = m_RootUI.FindChildTraversing( "GameOver");
        m_BackMenuBtn = Utilitys.FindChild<Button>(m_RootUI, "BackMenuBtn");
        m_Message = Utilitys.FindChild<Text>(m_RootUI, "Message");
        m_EnergySlider = Utilitys.FindChild<Slider>(m_RootUI, "EnergySlider");
        m_EnergyText = Utilitys.FindChild<Text>(m_RootUI, "EnergyText");

        m_Message.text = "";

        m_GameOverUI.SetActive(false);
    }

    public void ShowMsg(string msg)
    {
        m_Message.text = msg;
        m_MsgTimer = m_MsgTime;
    }

    public override void Update()
    {
        base.Update();
        UpdateAliveCount();
        if (m_MsgTimer > 0)
        {
            m_MsgTimer -= Time.deltaTime;
            if (m_MsgTimer <= 0)
            {
                m_MsgTimer = 0f;
                m_Message.text = "";
            }
        }
    }

    public void UpdateEnergySlider(int nowEnergy, int maxEnergy)
    {
        m_EnergySlider.value = (float)nowEnergy / maxEnergy;
        m_EnergyText.text = "(" + nowEnergy + "/" + maxEnergy + ")";
    }

    /// <summary>
    /// 访问者模式 访问所有角色,并根据需求返回
    /// </summary>
    public void UpdateAliveCount()
    {
        m_AliveCountVisitor.Reset();
        m_Facade.RunVisitor(m_AliveCountVisitor);
        m_SoldierCount.text = m_AliveCountVisitor.SoldierCount.ToString();
        m_EnemyCount.text = m_AliveCountVisitor.EnemyCount.ToString();
    }
}