
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WeaponRocket : IWeapon {

    public WeaponRocket(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject) { }


    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
    }

    protected override void PlaySound()
    {
    }

    protected override void SetEffectDisplayTime()
    {
    }
}