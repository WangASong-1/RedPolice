using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技能实例.每一个技能由多个技能原子组合成.
/// 普攻是没有CD的技能
/// </summary>
public class SkillInstance {
    public bool m_IsUsed = false;
    public List<ISkillTrigger> m_SkillTriggers = new List<ISkillTrigger>();

    protected ICharacter m_Character;

    public SkillInstance()
    {
    }

    public SkillInstance(SkillInstance other)
    {
        foreach(ISkillTrigger trigger in other.m_SkillTriggers)
        {
            m_SkillTriggers.Add(trigger);
        }
    }

    public ICharacter Character
    {
        get { return m_Character; }
    }

    public void Reset()
    {
        foreach (ISkillTrigger trigger in m_SkillTriggers)
        {
            trigger.Reset();
        }
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
        m_IsUsed = true;
    }

    public void Update(float dt)
    {
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
