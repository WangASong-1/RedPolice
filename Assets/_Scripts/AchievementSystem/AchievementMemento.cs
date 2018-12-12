using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 备忘录模式, 暂时不需要CareTake保存版本
/// </summary>
public class AchievementMemento
{
    public int EnemyKilledCount { get; set; }
    public int SoldierKilledCount { get; set; }
    public int MaxStageLv { get; set; }

    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyKilledCount", EnemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", SoldierKilledCount);
        PlayerPrefs.SetInt("MaxStageLv", MaxStageLv);
    }

    public void LoadData()
    {
        EnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
        SoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
        MaxStageLv = PlayerPrefs.GetInt("MaxStageLv");
    }
}

