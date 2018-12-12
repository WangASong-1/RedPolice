using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 适配器模式 将敌人变成友军.类似于宠物(因为战士的寻找敌人是寻找的敌人列表)
/// </summary>
public class SoldierCaptive : ISoldier
{
    private IEnemy m_Enemy;

    /// <summary>
    /// 俘兵营,利用适配器模式.
    /// 构造顺序按照SoldierBuilder建造者模式的顺序构建
    /// </summary>
    /// <param name="m_Enemy"></param>
    public SoldierCaptive(IEnemy m_Enemy)
    {
        this.m_Enemy = m_Enemy;
        ICharacterAttr attr = new SoldierAttr(m_Enemy.Attr.Strategy, 1, m_Enemy.Attr.BaseAttr);
        this.Attr = attr;

        this.GameObject = m_Enemy.GameObject;
        this.Weapon = m_Enemy.Weapon;
    }

    protected override void PlayEffect()
    {
        m_Enemy.PlayEffect();
    }

    protected override void PlaySound()
    {
    }
}

