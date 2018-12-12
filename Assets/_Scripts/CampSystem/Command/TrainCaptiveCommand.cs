using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 添加俘兵的命令
/// </summary>
public class TrainCaptiveCommand : ITrainCommand
{
    private EnemyType m_EnemyType;
    private WeaponType m_WeaponType;
    private Vector3 m_Position;
    private int m_Lv;

    public TrainCaptiveCommand(EnemyType m_EnemyType, WeaponType m_WeaponType, Vector3 m_Position, int m_Lv=1)
    {
        this.m_EnemyType = m_EnemyType;
        this.m_WeaponType = m_WeaponType;
        this.m_Position = m_Position;
        this.m_Lv = m_Lv;
    }

    public override void Execute()
    {
        IEnemy enemy = null;
        switch (m_EnemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(m_WeaponType, m_Position) as IEnemy;
                break;
            case EnemyType.Ogre:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(m_WeaponType, m_Position) as IEnemy;
                break;
            case EnemyType.Troll:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(m_WeaponType, m_Position) as IEnemy;
                break;
            default:
                Debug.LogError("无法创建俘兵" + m_EnemyType); return;
        }
        GameFacade.Instance.RemoveEnemy(enemy);
        SoldierCaptive captive = new SoldierCaptive(enemy);
        GameFacade.Instance.AddSoldier(captive);
    }
}

