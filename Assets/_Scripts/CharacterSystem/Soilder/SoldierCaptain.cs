
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 士兵：船长
/// 通过模板方法模式的方式实现UnderAttack
/// 
/// </summary>
public class SoldierCaptain : ISoldier {

    public SoldierCaptain() {
    }

    protected override void PlayEffect()
    {
        DoPlayEffect("CaptainDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("CaptainDeath");
    }
}