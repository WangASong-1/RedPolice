using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 强制位移原子
/// </summary>
public class ForceMoveTrigger : AbstrctSkillTrigger
{
    private float m_MoveSpeed = 1f;
    private Vector3 m_Dir;
    private Vector3 m_targetPos = new Vector3();
    private Vector3 m_startPos = new Vector3();
    private Vector3 m_lerpPos = new Vector3();
    public override ISkillTrigger Clone()
    {
        ForceMoveTrigger trigger = new ForceMoveTrigger();
        trigger.m_MoveSpeed = m_MoveSpeed;
        trigger.m_TypeName = m_TypeName;
        trigger.m_StartTime = m_StartTime;
        trigger.m_EndTime = m_EndTime;
        return trigger;
    }

    public override bool Enter(SkillInstance instance, float curTime)
    {
        //Debug.Log("ForceMoveTrigger Enter m_TypeName = " + m_TypeName);
        m_SkillInstance = instance;
        m_LifeTime = 0f;
        m_lerpPos = Vector3.zero;
        m_startPos = m_Character.Position;
        m_targetPos = m_Character.Position + m_Character.GameObject.transform.forward*-1;
        m_IsExecuting = true;
        return true;
    }

    public override bool Exit()
    {
        Debug.Log("ForceMoveTrigger = Exit");
        m_IsExecuting = false;
        return base.Exit();
    }

    /// <summary>
    /// 技能从文件加载的时候Init
    /// </summary>
    /// <param name="args"></param>
    public override void Init(string args)
    {
        m_TypeName = "ForceMoveTrigger";
        string[] argArray = args.Split(',');
        Debug.Log("args = " + args);
        m_StartTime = float.Parse( argArray[0]);
     
        m_EndTime = float.Parse(argArray[1]);
        Debug.Log("m_StartTime = " + m_StartTime);
        Debug.Log("m_EndTime = " + m_EndTime);
    }

    public override void ReadFromXml()
    {
        throw new System.NotImplementedException();
    }

    public override void Update(float dt)
    {
        if (!m_IsExecuting)
            return;
        m_LifeTime += dt;
        //不在生命周期内，不update
        if (m_LifeTime < m_StartTime || m_LifeTime > m_EndTime)
            return;
        m_lerpPos = Vector3.Lerp(m_startPos, m_targetPos, m_LifeTime - m_StartTime) - m_Character.Position;
        m_lerpPos.y = 0;
        m_Character.AddDeltaPosition(m_lerpPos);

        if (m_LifeTime >= m_EndTime)
        {
            Exit();
        }
    }

    public override void WriteIntoXml()
    {
        throw new System.NotImplementedException();
    }
}