
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SoldierSergeant : ISoldier {

    public SoldierSergeant() {
    }

    protected override void PlayEffect()
    {
        DoPlayEffect("SergeantDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("SergeantDeath");
    }
}