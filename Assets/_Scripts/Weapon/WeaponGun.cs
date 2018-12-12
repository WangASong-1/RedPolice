
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WeaponGun : IWeapon {

    public WeaponGun(WeaponBaseAttr baseAttr, GameObject gameObject):base(baseAttr, gameObject){}


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