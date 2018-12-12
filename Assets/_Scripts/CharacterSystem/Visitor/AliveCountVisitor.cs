using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// ICharacter是否还或者的 Vsitor
/// </summary>
public class AliveCountVisitor : ICharacterVisitor
{
    public int EnemyCount { get; set; }
    public int SoldierCount { get; set; }

    public void Reset()
    {
        EnemyCount = 0;
        SoldierCount = 0;
    }
    public override void VisitEnemy(IEnemy enemy)
    {
        if(!enemy.IsKilled)
            EnemyCount += 1;
    }

    public override void VisitSoldier(ISoldier soldier)
    {
        if (!soldier.IsKilled)
            SoldierCount += 1;
    }
}

