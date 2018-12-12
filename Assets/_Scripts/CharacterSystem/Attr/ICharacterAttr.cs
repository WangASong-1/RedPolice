using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 角色类的参数
/// </summary>
public class ICharacterAttr
{

    protected CharacterBaseAttr m_BaseAttr;
    protected int m_CurrentHP;
    

    /// <summary>
    /// 等级,升级提高增加的最大血量，抵御的伤害值
    /// </summary>
    protected int m_LV;
    

    /// <summary>
    /// 当前等级伤害减免的量
    /// </summary>
    protected int m_DmgDescValue;

    protected IAttrStrategy m_Strategy;

    public int CritValue { get { return m_Strategy.GetCritDmg(m_BaseAttr.CritRate); } }
    public int CurrentHP { get { return m_CurrentHP; } }
    public IAttrStrategy Strategy { get { return m_Strategy; } }
    public CharacterBaseAttr BaseAttr { get { return m_BaseAttr; } }

    //public int DmgDescValue { get { return m_DmgDescValue; } }
    //不使用方法返回是为了减少性能损耗
    //public int DmgDescValue { get { return m_Strategy.GetDmgDescValue(m_LV); } }

    public ICharacterAttr(IAttrStrategy strategy,int lv ,CharacterBaseAttr baseAttr)
    {
        m_Strategy = strategy;
        m_LV = lv;
        m_BaseAttr = baseAttr;

        m_DmgDescValue = m_Strategy.GetDmgDescValue(m_LV);
        m_CurrentHP = baseAttr.MaxHP + m_Strategy.GetExtraHPValue(m_LV);
    }

    public void TakeDamage(int damage)
    {
        damage -= m_DmgDescValue;
        if (damage < 5) damage = 5;
        m_CurrentHP -= damage;
    }
}
