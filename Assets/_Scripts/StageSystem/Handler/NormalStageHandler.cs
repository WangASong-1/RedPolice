using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class NormalStageHandler :IStageHandler
{
    
    private EnemyType m_EnemyType;
    private WeaponType m_WeaponType;
    private int m_Count;
    private Vector3 m_Position;

    private int m_SpawnTime = 1;
    private float m_SpawnTimer = 0f;
    private int m_CountSpawned = 0;

    public NormalStageHandler(StageSystem stageSystem, int lv, int countToFinished, EnemyType et, WeaponType wt, int count, Vector3 pos)
        :base(stageSystem,lv, countToFinished)
    {
        m_EnemyType = et;
        m_WeaponType = wt;
        m_Count = count;
        m_Position = pos;
        m_SpawnTimer = m_SpawnTime;
    }

    protected override void UpdateStage()
    {
        base.UpdateStage();

        if(m_CountSpawned < m_Count)
        {
            m_SpawnTimer -= Time.deltaTime;
            if(m_SpawnTimer <= 0)
            {
                SpawnEnemy();
                m_SpawnTimer = m_SpawnTime;
            }
        }
    }

    void SpawnEnemy()
    {
        m_CountSpawned++;
        switch (m_EnemyType)
        {
            case EnemyType.Elf:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(m_WeaponType, m_Position);
                break;
            case EnemyType.Ogre:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(m_WeaponType, m_Position);
                break;
            case EnemyType.Troll:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(m_WeaponType, m_Position);
                break;
            default:
                Debug.LogError("无法生成敌人,类型为: " + m_EnemyType);
                break;
        }
        //
    }
}

