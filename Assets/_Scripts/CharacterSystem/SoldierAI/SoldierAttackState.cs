﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierAttackState : ISoldierState
{
    public SoldierAttackState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        m_StateID = SoldierStateID.Attack;
        m_AttackTimer = m_AttackTime;
    }

    private float m_AttackTime = 1f;
    private float m_AttackTimer = 0;

    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
        m_Charater.StopMove();
    }
    
    /// <summary>
    /// 攻击状态机的攻击.
    /// </summary>
    public override void Act(List<ICharacter> targets)
    {
        if (targets.IsCountNull())
        {
            return;
        }
        m_AttackTimer += Time.deltaTime;
        //这里是攻击CD
        if (m_AttackTimer >= m_AttackTime)
        {
            //攻击成功，才返回，不然一直处于可以攻击状态
            //Debug.Log("SoldierAttackState::Act 战士攻击");
            if(m_Charater.Attack(targets[0]))
                m_AttackTimer = 0f;
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        //没敌人了,切换到待机状态
        if (targets.IsCountNull())
        {
            //Debug.Log("SoldierAttackState::Reason 攻击状态切换到待机状态");
            m_FSM.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(m_Charater.Position, targets[0].Position);
        //Debug.Log("distance = "+ distance);
        //超出攻击范围,切换到追记状态
        if(distance > m_Charater.AtkRange)
        {
            //Debug.Log("SoldierAttackState::Reason 攻击状态切换到追击状态");
            m_FSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}

