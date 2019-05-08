using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 播放动画的技能原子
/// </summary>
public class PlayAnimationTrigger : AbstrctSkillTrigger
{
    int m_AnimationId = 0;

    public override ISkillTrigger Clone()
    {
        return null;
    }

    public override bool Enter(SkillInstance instance, float curTime)
    {
        base.Enter(instance, curTime);
        Debug.Log("m_TypeName = " + m_TypeName);
        m_CurTime = curTime;

        return false;
    }

    public override void Init(string args)
    {
        m_TypeName = "PlayAnimation";
    }

    public override void ReadFromXml()
    {
        //throw new System.NotImplementedException();
    }

    public override void Update(float dt)
    {
        //throw new System.NotImplementedException();
    }

    public override void WriteIntoXml()
    {
        //throw new System.NotImplementedException();
    }
}
