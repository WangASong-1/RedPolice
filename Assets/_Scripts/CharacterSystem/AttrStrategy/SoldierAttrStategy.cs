using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SoldierAttrStategy : IAttrStrategy
{
    /// <summary>
    /// 战士没有暴击
    /// </summary>
    /// <param name="critRate"></param>
    /// <returns></returns>
    public int GetCritDmg(float critRate)
    {
        return 0;
    }

    public int GetDmgDescValue(int lv)
    {
        return (lv - 1) * 5;
    }

    public int GetExtraHPValue(int lv)
    {
        return (lv - 1) * 10;
    }
}

