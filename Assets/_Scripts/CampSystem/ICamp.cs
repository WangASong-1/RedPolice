using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public abstract class ICamp
{
    protected GameObject m_GameObject;
    protected string m_Name;
    protected string m_IconSprite;
    protected SoldierType m_SoldierType;
    protected Vector3 m_Position;//集合点
    protected float m_TrainTime;

    protected List<ITrainCommand> m_Commands;
    private float m_TrainTimer = 0;

    protected IEnergyCountStrategy m_EnergyCountStrategy;
    protected int m_EnergyCostCampUpgrade;
    protected int m_EnergyCostWeaponUpgrade;
    protected int m_EnergyCostTrain;

    public ICamp(GameObject gameObject, string name, string icon, SoldierType Soldiertype, Vector3 pos, float trainTime)
    {
        m_GameObject = gameObject;
        m_Name = name;
        m_IconSprite = icon;
        m_SoldierType = Soldiertype;
        m_Position = pos;
        m_TrainTime = trainTime;
        m_TrainTimer = m_TrainTime;
        m_Commands = new List<ITrainCommand>();
    }

    public virtual void Update() {
        UpdateCommand();
    }

    private void UpdateCommand()
    {
        if (m_Commands.IsCountNull())
        {
            return;
        }
        m_TrainTimer -= Time.deltaTime;
        if(m_TrainTimer <= 0)
        {
            m_Commands[0].Execute();
            m_Commands.RemoveAt(0);
            m_TrainTimer = m_TrainTime;
        }
    }


    public string Name { get { return m_Name; } }
    public string IconSprite { get { return m_IconSprite; } }

    public abstract int Lv { get; }
    public abstract WeaponType WeaponType { get; }
    public abstract int EnergyCostCampUpgrade { get; }
    public abstract int EnergyCostWeaponUpgrade { get; }
    public abstract int EnergyCostTrain { get; }

    public abstract void UpgradeCamp();
    public abstract void UpgradeWeapon();
    protected abstract void UpdateEnergyCost();
    public abstract void Train();

    public void CancelTrainCommand()
    {
        if (!m_Commands.IsCountNull())
        {
            m_Commands.RemoveAt(m_Commands.Count - 1);
            if (m_Commands.Count == 0)
            {
                m_TrainTimer = m_TrainTime;
            }
        }
    }

    public int TrainCount
    {

        get { return m_Commands.Count; }
    }

    public float TrainRemainingTime{get { return m_TrainTimer; }}

}

