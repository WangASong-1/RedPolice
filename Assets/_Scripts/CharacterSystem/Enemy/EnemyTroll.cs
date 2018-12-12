
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EnemyTroll : IEnemy {

    public EnemyTroll() {
    }

    public override void PlayEffect()
    {
        DoPlayEffect("TrollEffect");
    }
}