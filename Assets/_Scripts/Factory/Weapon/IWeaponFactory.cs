using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public interface IWeaponFactory
{
    IWeapon CreateWeapon(WeaponType weaponType);
}

