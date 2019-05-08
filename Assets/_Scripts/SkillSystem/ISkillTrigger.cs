using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkilltriggerExecuteType
{
    other
}

/// <summary>
/// 技能原子
/// </summary>
public interface ISkillTrigger {
    void Init(string args);
    void Reset();
    ISkillTrigger Clone();
    /// <summary>
    /// 技能原子执行。
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="curTime">当前时间</param>
    /// <returns></returns>
    bool Enter(SkillInstance instance, float curTime);
    float GetStartTime();
    bool IsExecuted();
    SkilltriggerExecuteType GetExecuteType();
    string GetTypeName();


    void ReadFromXml();
    void WriteIntoXml();
    void Update(float dt);
    void AttachToCharacter(ICharacter character);
}
