using UnityEngine;

public class EnemyAttrStategy : IAttrStrategy
{
    public int GetCritDmg(float critRate)
    {
        if (Random.Range(0, 1f) < critRate)
        {
            return (int)(10 * Random.Range(0, 1f));
        }
        return 0;
    }

    public int GetDmgDescValue(int lv)
    {
        return 0;
    }

    public int GetExtraHPValue(int lv)
    {
        return 0;
    }
}

