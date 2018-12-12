using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 访问者模式 Visitor
/// </summary>
public abstract class ICharacterVisitor
{
    public abstract void VisitEnemy(IEnemy enemy);
    public abstract void VisitSoldier(ISoldier soldier);
}

