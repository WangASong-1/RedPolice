using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 播放动画的技能原子
/// </summary>
public class PlayAnimationTrigger : AbstrctSkillTrigger
{
    int m_AnimationId = 0;
    private string m_AnimationName;
    private bool m_IsPlayed = false;

    public override ISkillTrigger Clone()
    {
        return null;
    }

    public override bool Enter(SkillInstance instance, float curTime)
    {
        base.Enter(instance, curTime);
        Debug.Log("m_TypeName = " + m_TypeName);
        m_CurTime = curTime;
        m_LifeTime = 0f;
        return false;
    }

    public override void Init(string args)
    {
        m_TypeName = "PlayAnimation";
        string[] argArray = args.Split(',');
        m_StartTime = float.Parse(argArray[0]);
        m_EndTime = float.Parse(argArray[1]);
        m_AnimationName = argArray[2];
    }

    public override void ReadFromXml()
    {
        //throw new System.NotImplementedException();
    }

    public override void Update(float dt)
    {
        m_LifeTime += dt;
        //Debug.Log("m_LifeTime = "+ m_LifeTime);
        if (m_LifeTime < m_StartTime || m_LifeTime > m_EndTime)
        {
            Exit();
            return;
        }
        if (!m_IsPlayed)
            m_SkillInstance.Character.PlayAnim(m_AnimationName);
    }

    public override void WriteIntoXml()
    {
        //throw new System.NotImplementedException();
    }
}
