
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SoldierRookie : ISoldier {

    public SoldierRookie() {
    }

    protected override void PlayEffect()
    {
        DoPlayEffect("RookieDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("RookieDeath");
    }
}