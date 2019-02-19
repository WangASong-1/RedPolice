using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class EnemyAttackState : IEnemyState
{
    public EnemyAttackState(EnemyFSMSystem fsm, ICharacter charater) : base(fsm, charater)
    {
        m_StateID = EnemyStateID.Attack;
        m_AttackTimer = m_AttackTime;
    }

    private float m_AttackTime = 1f;
    private float m_AttackTimer = 0;

    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
        m_Charater.StopMove();

    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets.IsCountNull()) return;
        m_AttackTimer += Time.deltaTime;
        if(m_AttackTimer >= m_AttackTime)
        {
            m_Charater.Attack(targets[0]);
            m_AttackTimer = 0f;
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets.IsCountNull())
        {
            m_FSM.PerformTransition(EnemyTransition.LostSoldier);
        }
        else
        {
            float distance = Vector3.Distance(m_Charater.Position, targets[0].Position);

        }
    }
}

