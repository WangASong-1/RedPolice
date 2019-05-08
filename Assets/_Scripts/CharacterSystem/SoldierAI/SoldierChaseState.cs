using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        m_StateID = SoldierStateID.Chase;
    }

    public override void Act(List<ICharacter> targets)
    {
        if(targets != null && targets.Count > 0)
        {
            m_Charater.MoveTo(targets[0].Position);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null && targets.Count == 0)
        {
            //Debug.Log("SoldierChaseState::Reason 追击状态切换到待机状态");
            m_FSM.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(targets[0].Position, m_Charater.Position);
        if(distance <= m_Charater.AtkRange)
        {
            //Debug.Log("SoldierChaseState::Reason 追击状态切换到攻击状态");
            m_FSM.PerformTransition(SoldierTransition.CanAttack);
        }
    }

}

