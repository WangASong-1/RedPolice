using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 像状态模式：有enter,有exit，但没有内部状态切换
/// 不像观察者模式：只update,没有其他联系。所以不是
/// </summary>
public abstract class AbstrctSkillTrigger : ISkillTrigger {
    protected float m_StartTime = 0f;
    protected float m_EndTime;
    protected float m_LifeTime;
    protected float m_CurTime;

    protected bool m_IsExecuting = false;
    protected string m_TypeName;
    protected SkilltriggerExecuteType m_ExecuteType = SkilltriggerExecuteType.other;
    protected ICharacter m_Character;
    protected SkillInstance m_SkillInstance;

    /// <summary>
    /// 各自解析需要的参数
    /// </summary>
    /// <param name="args"></param>
    public abstract void Init(string args);

    public virtual void Reset()
    {
        m_IsExecuting = false;
    }

    public abstract ISkillTrigger Clone();

    /// <summary>
    /// Enter方法
    /// </summary>
    public virtual bool Enter(SkillInstance instance, float curTime)
    {
        m_SkillInstance = instance;
        m_IsExecuting = true;
        return true;
    }

    public virtual bool Exit()
    {
        m_IsExecuting = false;
        return true;
    }

    public float GetStartTime()
    {
        return m_StartTime;
    }

    public float GetEndTime()
    {
        return m_EndTime;
    }

    public bool IsExecuted()
    {
        return m_IsExecuting;
    }

    public SkilltriggerExecuteType GetExecuteType()
    {
        return m_ExecuteType;
    }

    public string GetTypeName()
    {
        return m_TypeName;
    }

    public abstract void ReadFromXml();
   

    public abstract void WriteIntoXml();

    public abstract void Update(float dt);

    public void AttachToCharacter(ICharacter character)
    {
        //Debug.Log(" aaaaaaaaaaaaa = " + character.GameObject.name);

        if(m_Character != null)
        {
            //Debug.Log(" 333333333333333333333333333333333333333 = " + m_Character.GameObject.name);

        }
        m_Character = character;
    }

   
}
