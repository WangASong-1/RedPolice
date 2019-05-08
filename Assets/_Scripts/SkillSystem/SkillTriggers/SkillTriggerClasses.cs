using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 播放动画的技能原子
/// </summary>
public class ForceMoveTrigger : AbstrctSkillTrigger
{
    private float m_MoveSpeed = 1f;
    private Vector3 m_Dir;
    public override ISkillTrigger Clone()
    {
        return null;
    }

    public override bool Enter(SkillInstance instance, float curTime)
    {
        Debug.Log("m_TypeName = " + m_TypeName);
        m_SkillInstance = instance;
        //m_CurTime = curTime;
        m_LifeTime = 0f;
        Debug.Log("m_StartTime = " + m_StartTime);
        Debug.Log("m_EndTime = " + m_EndTime);
        return true;
    }

    public override bool Exit()
    {
        m_SkillInstance.m_IsUsed = false;
        return base.Exit();
    }

    public override void Init(string args)
    {
        m_TypeName = "ForceMoveTrigger";
        string[] argArray = args.Split(',');
        m_StartTime = float.Parse( argArray[0]);
        m_EndTime = float.Parse(argArray[1]);
     
    }

    public override void ReadFromXml()
    {
        throw new System.NotImplementedException();
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
        m_Character.AddDeltaPosition(Vector3.forward*30/(m_EndTime - m_StartTime) * dt);
    }

    public override void WriteIntoXml()
    {
        throw new System.NotImplementedException();
    }
}