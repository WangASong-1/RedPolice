
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// ʿ��������
/// ͨ��ģ�巽��ģʽ�ķ�ʽʵ��UnderAttack
/// 
/// </summary>
public class SoldierCaptain : ISoldier {

    public SoldierCaptain() {
    }

    protected override void PlayEffect()
    {
        DoPlayEffect("CaptainDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("CaptainDeath");
    }
}