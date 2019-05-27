using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技能实例.每一个技能由多个技能原子组合成.
/// 普攻是没有CD的技能
/// </summary>
public class SkillInstance {
    public List<ISkillTrigger> m_SkillTriggers = new List<ISkillTrigger>();

    protected ICharacter m_Character;
    private float m_SkillEndTime = 0f;
    private float m_SkillRunTime = 0f;
    private bool b_IsSkillEnd = false;

    public SkillInstance()
    {
    }

    public SkillInstance(SkillInstance other)
    {
        foreach(ISkillTrigger trigger in other.m_SkillTriggers)
        {
            m_SkillTriggers.Add(trigger);
            m_SkillEndTime = trigger.GetEndTime() > m_SkillEndTime ? trigger.GetEndTime() : m_SkillEndTime;
            Debug.Log("rigger.GetEndTime() = "+ trigger.GetEndTime());
        }
        //避免技能最后一帧无法update
        m_SkillEndTime += Time.deltaTime*5f;
    }

    public ICharacter Character
    {
        get { return m_Character; }
    }

    public bool IsSkillEnd
    {
        get
        {
            return b_IsSkillEnd;
        }

        set
        {
            b_IsSkillEnd = value;
        }
    }

    public void Reset()
    {
        foreach (ISkillTrigger trigger in m_SkillTriggers)
        {
            trigger.Reset();
        }
        m_SkillRunTime = 0f;
    }

    public void AttachToCharacter(ICharacter character)
    {
        m_Character = character;
        foreach (ISkillTrigger trigger in m_SkillTriggers)
        {
            trigger.AttachToCharacter(character);
        }
    }

    public void Execute(float curTime)
    {
        foreach (ISkillTrigger trigger in m_SkillTriggers)
        {
            trigger.Enter(this,curTime);
        }
        Debug.Log("m_SkillRunTime = " + m_SkillRunTime);
        Debug.Log("m_SkillEndTime = " + m_SkillEndTime);
        m_SkillRunTime = 0f;
        b_IsSkillEnd = false;

    }

    public void Update(float dt)
    {
        m_SkillRunTime += dt;
        //Debug.Log("m_SkillRunTime = " + m_SkillRunTime);

        if (m_SkillRunTime > m_SkillEndTime)
        {
            Debug.Log("技能执行完了 -----------------------");
            b_IsSkillEnd = true;
            return;
        }
        foreach (ISkillTrigger trigger in m_SkillTriggers)
        {
            trigger.Update(dt);
        }
    }

    public int GetTriggerCount(string typeName)
    {
        Debug.Log("typeName = " + typeName);
        int count = 0;
        foreach(ISkillTrigger trigger in m_SkillTriggers)
        {
            if (trigger.GetTypeName() == typeName)
                ++count;
        }
        return count;
    }

}
