
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WeaponRifle : IWeapon {

    public WeaponRifle(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject) { }


    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.5f, targetPosition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("");
    }

    protected override void SetEffectDisplayTime()
    {
        
    }
}