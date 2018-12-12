
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public enum SoldierType
{
    Rookie,
    Sergeant,
    Captain,
    Captive
}
public abstract class ISoldier : ICharacter {
    protected SoldierFSMSystem m_FSMSystem;

    public ISoldier():base()
    {
        MakeFSM();
    }

    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        if (m_IsKilled) return;
        m_FSMSystem.CurrentState.Reason(targets);
        m_FSMSystem.CurrentState.Act(targets);
    }

    private void MakeFSM()
    {
        m_FSMSystem = new SoldierFSMSystem();
        SoldierIdleState idleState = new SoldierIdleState(m_FSMSystem,this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(m_FSMSystem, this);
        chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttackState attackState = new SoldierAttackState(m_FSMSystem, this);
        attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        m_FSMSystem.AddState(idleState, chaseState, attackState);
    }

    /// <summary>
    /// 战士只有死亡特效和死亡声音
    /// </summary>
    /// <param name="damage"></param>
    public override void UnderAttack(int damage)
    {
        if (m_IsKilled) return;
        base.UnderAttack(damage);

        if (m_Attr.CurrentHP <= 0)
        {
            PlaySound();
            PlayEffect();
            Killed();
            /*
            DoPlaySound("");
            DoPlayEffect("");
            Killed();
            */
        }
    }

    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotyfySubject(GameEventType.SoldierKilled);
    }

    protected abstract void PlaySound();
    protected abstract void PlayEffect();

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitSoldier(this);
    }
}