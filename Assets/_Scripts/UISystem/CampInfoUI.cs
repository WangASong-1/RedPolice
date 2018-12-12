
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

/// <summary>
/// 兵营Panel
/// </summary>
public class CampInfoUI : IBaseUI {
    private Image m_CampIcon;
    private Text m_CampName;
    private Text m_CampLevel;
    private Text m_WeaponLevel;
    private Button m_CampUpgradeBtn;
    private Button m_WeaponUpgradeBtn;
    private Button m_TrainBtn;
    private Text m_TrainBtnText;
    private Button m_CancelTrainBtn;
    private Text m_AliveCount;
    private Text m_TrainingCount;
    private Text m_TrainTime;

    private ICamp m_Camp;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        m_RootUI = canvas.FindChildTraversing("CampInfoUI");

        m_CampIcon = Utilitys.FindChild<Image>(m_RootUI, "CampIcon");
        m_CampName = Utilitys.FindChild<Text>(m_RootUI, "CampName");
        m_CampLevel = Utilitys.FindChild<Text>(m_RootUI, "CampLv");
        m_WeaponLevel = Utilitys.FindChild<Text>(m_RootUI, "WeaponLv");
        m_CampUpgradeBtn = Utilitys.FindChild<Button>(m_RootUI, "CampUpgradeBtn");
        m_WeaponUpgradeBtn = Utilitys.FindChild<Button>(m_RootUI, "WeaponUpgradeBtn");
        m_TrainBtn = Utilitys.FindChild<Button>(m_RootUI, "TrainBtn");
        m_TrainBtnText = Utilitys.FindChild<Text>(m_RootUI, "TrainBtnText");
        m_CancelTrainBtn = Utilitys.FindChild<Button>(m_RootUI, "CancelTrainBtn");
        m_AliveCount = Utilitys.FindChild<Text>(m_RootUI, "AliveCount");
        m_TrainingCount = Utilitys.FindChild<Text>(m_RootUI, "TrainningCount");
        m_TrainTime = Utilitys.FindChild<Text>(m_RootUI, "TrainTime");

        m_TrainBtn.onClick.AddListener(OnTrainClick);
        m_CancelTrainBtn.onClick.AddListener(OnCancelTrainClick);
        m_CampUpgradeBtn.onClick.AddListener(OnCampUpgradeClick);
        m_WeaponUpgradeBtn.onClick.AddListener(OnWeaponUpgradeClick);


        Hide();
    }

    public override void Update()
    {
        base.Update();
        if(m_Camp!=null)
        {
            ShowTrainingInfo();
        }

    }

    public void ShowCampInfo(ICamp camp)
    {
        Show();
        m_Camp = camp;
        m_CampIcon.sprite = FactoryManager.AssetFactory.LoadSprite(camp.IconSprite);
        m_CampName.text = camp.Name;
        m_CampLevel.text = camp.Lv.ToString();
        ShowWeaponLevel(m_Camp.WeaponType);
        m_TrainBtnText.text = "训练\n" + m_Camp.EnergyCostTrain + "点能量";

        ShowTrainingInfo();
    }

    private void ShowTrainingInfo()
    {
        m_TrainingCount.text = m_Camp.TrainCount.ToString();
        m_TrainTime.text = m_Camp.TrainRemainingTime.ToString("0.00");
        if (m_Camp.TrainCount == 0)
        {
            m_CancelTrainBtn.interactable = false;
        }
        else
        {
            m_CancelTrainBtn.interactable = true;

        }
    }

    void ShowWeaponLevel(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Gun:
                m_WeaponLevel.text = "短枪";
                break;
            case WeaponType.Rifle:
                m_WeaponLevel.text = "长枪";
                break;
            case WeaponType.Rocket:
                m_WeaponLevel.text = "火箭";
                break;
            default:
                break;
        }
    }

    private void OnTrainClick()
    {
        //判断能量是否足够
        //TODO
        int energy = m_Camp.EnergyCostTrain;
        if (GameFacade.Instance.TakeEnergy(energy))
        {
            m_Camp.Train();
        }
        else
        {
            GameFacade.Instance.ShowMsg("训练士兵需要能量:" + energy + "能量不足,无法训练新的士兵");
        }
    }

    private void OnCancelTrainClick()
    {
        m_Facade.RecycleEnergy(m_Camp.EnergyCostTrain);
        //回收能量 TODO
        m_Camp.CancelTrainCommand();
    }

    private void OnCampUpgradeClick()
    {
        int energy = m_Camp.EnergyCostCampUpgrade;
        if(energy < 0)
        {
            m_Facade.ShowMsg("兵营已经最大等级,无法再升级");
            return;
        }
        if (m_Facade.TakeEnergy(energy))
        {
            m_Camp.UpgradeCamp();
            ShowCampInfo(m_Camp);
        }
        else{
            m_Facade.ShowMsg("升级兵营需要能量:" + energy + "能量不足,请稍后升级");

        }

    }
    private void OnWeaponUpgradeClick()
    {
        int energy = m_Camp.EnergyCostWeaponUpgrade;
        if (energy < 0)
        {
            m_Facade.ShowMsg("武器已经最大等级,无法再升级");
            return;
        }
        if (m_Facade.TakeEnergy(energy))
        {
            m_Camp.UpgradeWeapon();
            ShowCampInfo(m_Camp);
        }
        else
        {
            m_Facade.ShowMsg("升级武器需要能量:"+ energy +" 能量不足,请稍后升级");

        }
    }
}