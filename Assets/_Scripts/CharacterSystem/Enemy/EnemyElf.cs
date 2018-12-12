
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EnemyElf : IEnemy {

    public EnemyElf() {
    }

    public override void PlayEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}