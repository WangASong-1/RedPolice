using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 命令模式中的 Command
/// 要做的事写入到这里
/// </summary>
public class TrainSoldierCommand : ITrainCommand
{
    SoldierType m_SoldierType;
    WeaponType m_WeaponType;
    Vector3 m_Position;
    int m_Lv;

    public TrainSoldierCommand(SoldierType st, WeaponType wt, Vector3 pos, int lv)
    {
        m_SoldierType = st;
        m_WeaponType = wt;
        m_Position = pos;
        m_Lv = lv;
    }

    /// <summary>
    /// 执行命令.
    /// 这里我可以将 工厂多创建几个,并且确定他们的类型
    /// </summary>
    public override void Execute()
    {
        //aSong:这个switch使用 在工厂类中注册泛型工厂解决
        switch (m_SoldierType)
        {
            case SoldierType.Rookie:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierRookie>(m_WeaponType, m_Position, m_Lv);
                break;
            case SoldierType.Sergeant:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierSergeant>(m_WeaponType, m_Position, m_Lv);

                break;
            case SoldierType.Captain:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierCaptain>(m_WeaponType, m_Position, m_Lv);

                break;
            default:
                Debug.LogError("无法执行命令,无法根据 type = [" + m_SoldierType + "] 生成士兵");
                break;
        }
    }
}

