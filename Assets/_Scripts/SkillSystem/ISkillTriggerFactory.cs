using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillTriggerFactory {
    ISkillTrigger CreateTrigger(string args);
}

/// <summary>
/// 技能原子工厂.用来创建技能原子用的。里面有两个List用池的方式管理原子
/// </summary>
/// <typeparam name="T"></typeparam>
public class SkillTriggerFactory<T> : ISkillTriggerFactory where T : ISkillTrigger, new()
{
    protected List<T> m_UsedSkillTriggers = new List<T>();
    protected List<T> m_UnusedSkillTriggers = new List<T>();


    public ISkillTrigger CreateTrigger(string args)
    {
        T trigger;
        if (m_UnusedSkillTriggers.Count > 0)
        {
            trigger = m_UnusedSkillTriggers[0];
            m_UnusedSkillTriggers.Remove(trigger);
        }
        else
        {
            trigger = new T();
        }
        trigger.Init(args);
        m_UsedSkillTriggers.Add(trigger);
        return (ISkillTrigger)trigger;
    }
}