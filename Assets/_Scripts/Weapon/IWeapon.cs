using UnityEngine;

public enum WeaponType
{
    Gun=0,
    Rifle=1,
    Rocket=2,
    MAX
}

public abstract class IWeapon {

    protected WeaponBaseAttr m_BaseAttr;
    protected int m_AtkPlusValue;

    protected GameObject m_GameObject;
    protected ICharacter m_Owner;
    protected ParticleSystem m_Particle;
    protected LineRenderer m_Line;
    protected Light m_Light;
    protected AudioSource m_AuidoSource;

    protected float m_EffectDisplayTime;

    public float AtkRange
    {
        get { return m_BaseAttr.AtkRange; }
    }

    public int Atk { get { return m_BaseAttr.Atk; } }

    public ICharacter Owner { set { m_Owner = value; } }

    public GameObject GameObject { get { return m_GameObject; } }

    public IWeapon(WeaponBaseAttr baseAttr, GameObject gameObject)
    {
        m_BaseAttr = baseAttr;
        m_GameObject = gameObject;
        Transform effect = m_GameObject.transform.Find("Effect");
        m_Particle = effect.GetComponent<ParticleSystem>();
        m_Line = effect.GetComponent<LineRenderer>();
        m_Light = effect.GetComponent<Light>();
        m_AuidoSource = effect.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if(m_EffectDisplayTime > 0)
        {
            m_EffectDisplayTime -= Time.deltaTime;
            if (m_EffectDisplayTime <= 0)
            {
                DisableEffect();
            }
        }
    }

    /// <summary>
    /// 模板方法模式
    /// </summary>
    public void Fire(Vector3 targetPosition)
    {
        //显示枪口特效
        PlayMuzzleEffect();

        //显示子弹轨迹特效
        PlayBulletEffect(targetPosition);

        //设置特效显示时间
        SetEffectDisplayTime();

        //播放声音
        PlaySound();
    }

    protected abstract void SetEffectDisplayTime();
    protected void DoSetEffectDisplayTime(float effectDisplayTime)
    {
        m_EffectDisplayTime = effectDisplayTime;
    }

    protected virtual void PlayMuzzleEffect()
    {
        //显示枪口特效
        m_Particle.Stop();
        m_Particle.Play();
        m_Light.enabled = true;
    }

    //显示子弹轨迹特效
    protected abstract void PlayBulletEffect(Vector3 targetPosition);
    protected void DoPlayBulletEffect(float width, Vector3 targetPosition)
    {
        m_Line.enabled = true;
        m_Line.startWidth = width;
        m_Line.endWidth = width;
        m_Line.SetPosition(0, m_GameObject.transform.position);
        m_Line.SetPosition(1, targetPosition);
    }

    protected abstract void PlaySound();
    protected void DoPlaySound(string clipName)
    {
        AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(clipName);
        m_AuidoSource.clip = clip;
        m_AuidoSource.Play();
    }

    private void DisableEffect()
    {
        m_Line.enabled = false;
        m_Light.enabled = false;
    }
}