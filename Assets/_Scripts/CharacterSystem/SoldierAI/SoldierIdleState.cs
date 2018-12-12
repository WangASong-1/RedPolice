using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierIdleState : ISoldierState
{
    public SoldierIdleState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        m_StateID = SoldierStateID.Idle;
    }

    public override void Act(List<ICharacter> targets)
    {
        
    }

    public override void Reason(List<ICharacter> targets)
    {
        //Debug.Log("SoldierIdleState::Reason 看见丧尸,切换状态");
        if(targets != null && targets.Count > 0)
        {
            //Debug.Log("SoldierIdleState::Reason 待机状态切换到追击状态");
            m_FSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}

