using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 建造者模式Directoer类.
/// </summary>
public class CharacterBuilderDirector
{
    public static ICharacter Constructer(ICharacterBuilder builder)
    {
        builder.AddCharacterAttr();
        builder.AddGameObject();
        builder.AddWeapon();
        builder.AddInCharacterSystem();
        return builder.GetResult();
    }
}

