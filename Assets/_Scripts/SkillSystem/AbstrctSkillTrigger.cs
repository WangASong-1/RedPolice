using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstrctSkillTrigger : ISkillTrigger {
    protected float m_StartTime = 0f;
    protected float m_EndTime;
    protected float m_LifeTime;
    protected float m_CurTime;

    protected bool m_IsExecuted = false;
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
        m_IsExecuted = false;
    }

    public abstract ISkillTrigger Clone();

    /// <summary>
    /// Enter方法
    /// </summary>
    public virtual bool Enter(SkillInstance instance, float curTime)
    {
        m_SkillInstance = instance;
        return true;
    }

    public virtual bool Exit()
    {
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
        return m_IsExecuted;
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
        m_Character = character;
    }

   
}
