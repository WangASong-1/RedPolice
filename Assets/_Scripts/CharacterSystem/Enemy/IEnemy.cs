
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public enum EnemyType
{
    Elf,
    Ogre,
    Troll
}
public abstract class IEnemy : ICharacter {

    protected EnemyFSMSystem m_FSMSystem;

    public IEnemy()
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
        m_FSMSystem = new EnemyFSMSystem();
        EnemyChaseState chaseState = new EnemyChaseState(m_FSMSystem, this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

        EnemyAttackState attackState = new EnemyAttackState(m_FSMSystem, this);
        attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

        m_FSMSystem.AddState(chaseState, attackState);
    }

    /// <summary>
    /// 敌人只有死亡特效
    /// </summary>
    /// <param name="damage"></param>
    public override void UnderAttack(int damage)
    {
        if (m_IsKilled) return;
        base.UnderAttack(damage);
        
        if(m_Attr.CurrentHP < 0)
        {
            //被攻击效果
            Killed();
            PlayEffect();
        }

    }

    public abstract void PlayEffect();

    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotyfySubject(GameEventType.EnemyKilled);
    }

    /// <summary>
    /// 执行访问
    /// </summary>
    /// <param name="visitor"></param>
    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitEnemy(this);
    }
}