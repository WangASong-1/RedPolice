
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//这个也相当于属于中介者模式了.通过角色类中转
/// <summary>
/// 基础角色类
/// 通过中介者模式,将多个类 IWeapon, ICharacterAttr通过ICharacter来进行交互
/// 通过桥接模式,将本来多个角色各自持有不同的武器,双双抽象后,达到降低耦合度
/// 通过MVC模式,将数据model 与角色View分离,到达后期同样的V可以通过赋予不同的model实现的效果
/// 通过访问者模式,提供外部可拓展的
/// </summary>
public abstract class ICharacter {
    //属性放到一个属性类中,方便换角色. m 与 v分离
    protected ICharacterAttr m_Attr;
    protected GameObject m_GameObject;
    protected NavMeshAgent m_Nav;
    protected AudioSource m_AudioSource;
    protected Animation m_Anim;
    //桥接模式==多肽?
    protected IWeapon m_Weapon;

    protected bool m_IsKilled = false;
    protected bool m_CanDestroy = false;

    private float m_DestroyTimer = 2f;

    public IWeapon Weapon
    {
        set
        {
            m_Weapon = value;
            m_Weapon.Owner = this;
            //Transform weaponPoint = m_GameObject.transform.Find();
            GameObject child = m_GameObject.FindChildTraversing("weapon-point");
            Utilitys.Attach(child, m_Weapon.GameObject);
        }
        get
        {
            return m_Weapon;
        }
    }


    public Vector3 Position
    {
        get {
            if (m_GameObject == null)
            {
                Debug.LogError("m_GameObject 为空");
                return Vector3.zero;
            }
            return m_GameObject.transform.position;
        }
    }

    public float AtkRange
    {
        get{return m_Weapon.AtkRange;}
    }
    public bool CanDestroy { get { return m_CanDestroy; } }
    public bool IsKilled { get { return m_IsKilled; } }
    public ICharacterAttr Attr { set { m_Attr = value; } get { return m_Attr; } }
    public GameObject GameObject
    {
        set {
            m_GameObject = value;
            m_Nav = m_GameObject.GetComponent<NavMeshAgent>();
            m_AudioSource = m_GameObject.GetComponent<AudioSource>();
            m_Anim = m_GameObject.GetComponentInChildren<Animation>();
        }
        get { return m_GameObject; }
    }

    public void Update()
    {
        if (m_IsKilled && !m_CanDestroy)
        {
            m_DestroyTimer -= Time.deltaTime;
            if(m_DestroyTimer <= 0)
            {
                m_CanDestroy = true;
            }
        }
        m_Weapon.Update();
    }
    
    /// <summary>
    /// AI策略的Update
    /// </summary>
    /// <param name="targets"></param>
    public abstract void UpdateFSMAI(List<ICharacter> targets);
    /// <summary>
    /// 访问者模式 Run
    /// </summary>
    /// <param name="visitor"></param>
    public abstract void RunVisitor(ICharacterVisitor visitor);
    public void Attack(ICharacter target)
    {
        m_Weapon.Fire(target.Position);
        m_GameObject.transform.LookAt(target.Position);
        PlayAnim("attack");
        target.UnderAttack(m_Weapon.Atk + m_Attr.CritValue);
    }

    public virtual void UnderAttack(int damage)
    {
        m_Attr.TakeDamage(damage);
    }

    public virtual void Killed()
    {
        //Debug.Log("ICharacter::Killed");
        m_IsKilled = true;
        m_Nav.Stop();

    }

    public void Release()
    {
        GameObject.Destroy(m_GameObject);
        Debug.Log("Release ");
    }
    public void PlayAnim(string animName)
    {
        m_Anim.CrossFade(animName);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        m_Nav.SetDestination(targetPosition);
        PlayAnim("move");
    }

    protected void DoPlaySound(string soundName)
    {
        AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(soundName);
        m_AudioSource.clip = clip;
        m_AudioSource.Play();
    }
    protected void DoPlayEffect(string effectName)
    {
        GameObject effectGo = FactoryManager.AssetFactory.LoadEffect(effectName);
        effectGo.transform.position = Position;
        effectGo.AddComponent<DestroyForTime>();
    }
}