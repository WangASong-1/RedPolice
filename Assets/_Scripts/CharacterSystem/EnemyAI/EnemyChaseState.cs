using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class EnemyChaseState : IEnemyState
{
    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter charater) : base(fsm, charater)
    {
        m_StateID = EnemyStateID.Chase;
    }

    /// <summary>
    /// 没有战士了,敌人就直接走向结束点
    /// </summary>
    private Vector3 m_TargetPosition;
    public override void DoBeforeEntering()
    {
        m_TargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public override void Act(List<ICharacter> targets)
    {
        if (!targets.IsCountNull())
        {
            m_Charater.MoveTo(targets[0].Position);
        }
        else
        {
            m_Charater.MoveTo(m_TargetPosition);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (!targets.IsCountNull())
        {
            //TODO
            float distance = Vector3.Distance(m_Charater.Position, targets[0].Position);
            if(distance < m_Charater.AtkRange)
            {
                m_FSM.PerformTransition(EnemyTransition.CanAttack);
            }
        }
    }
}

