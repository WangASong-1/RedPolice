
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EnemyOgre : IEnemy {

    public EnemyOgre() {
    }

    public override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}