using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T:ICharacter,new()
    {
        ICharacter soldier = new T();

        ICharacterBuilder builder = new SoldierBuilder(soldier, typeof(T), weaponType, spawnPosition, lv);
        return CharacterBuilderDirector.Constructer(builder);
    }
}

