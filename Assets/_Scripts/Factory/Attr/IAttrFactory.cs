using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public interface IAttrFactory
{
    CharacterBaseAttr GetCharacterBaseAttr(string str);
    WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType);
}

