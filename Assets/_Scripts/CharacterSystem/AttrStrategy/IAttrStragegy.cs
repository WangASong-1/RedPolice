using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 策略模式
/// 定义了：升级增加的血量，升级后的伤害减免，暴击伤害的随机值
/// </summary>
public interface IAttrStrategy
{
    int GetExtraHPValue(int lv);
    int GetDmgDescValue(int lv);
    int GetCritDmg(float critRate);
}
