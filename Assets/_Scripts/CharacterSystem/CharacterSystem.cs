using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

/// <summary>
/// 角色系统管理类：负责添加移除Update以及Visit ICharacter实例
/// </summary>
public class CharacterSystem : IGameSystem {
    private List<ICharacter> m_Enemys = new List<ICharacter>();
    private List<ICharacter> m_Soldiers = new List<ICharacter>();
    public CharacterSystem() {
    }

    public void AddEnemy(IEnemy enemy)
    {
        m_Enemys.Add(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        m_Enemys.Remove(enemy);
    }

    public void AddSoldier(ISoldier soldier)
    {
        m_Soldiers.Add(soldier);
    }

    public void RemoveSoldier(ISoldier soldier)
    {
        m_Soldiers.Remove(soldier);
    }

    
    public override void Update()
    {
        UpdateEnemy();
        UpdateSoldier();
        RemoveCharacterIsKilled(m_Enemys);
        RemoveCharacterIsKilled(m_Soldiers);
    }

    private void UpdateEnemy()
    {
        foreach (var enemy in m_Enemys)
        {
            //Debug.Log("死亡, 移除 " + enemy.GameObject.name);

            enemy.Update();
            enemy.UpdateFSMAI(m_Soldiers);
        }
    }

    private void UpdateSoldier()
    {
        foreach (var soldier in m_Soldiers)
        {
            //Debug.Log("死亡, 移除 " + soldier.GameObject.name);
            soldier.Update();
            soldier.UpdateFSMAI(m_Enemys);
        }
    }

    /// <summary>
    /// 这个可以放在UpdateEnemy和UpdateSoldier里面去,也可以不需要new List.减少堆分配
    /// </summary>
    /// <param name="characters"></param>
    private void RemoveCharacterIsKilled(List<ICharacter> characters)
    {
        List<ICharacter> canDestroyes = new List<ICharacter>();
        foreach(var c in characters)
        {
            if (c.CanDestroy)
            {
                canDestroyes.Add(c);
            }
        }

        foreach(var c in canDestroyes)
        {
            Debug.Log("死亡, 移除 " +c.GameObject.name);
            c.Release();
            characters.Remove(c);
        }
    }

    /// <summary>
    /// 访问者模式, 将Visitor传进来，并各个角色执行访问
    /// </summary>
    /// <param name="visitor"></param>
    public void RunVisitor(ICharacterVisitor visitor)
    {
        foreach (var item in m_Enemys)
        {
            item.RunVisitor(visitor);
        }
        foreach (var item in m_Soldiers)
        {
            item.RunVisitor(visitor);
        }
    }
}