
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// ���������Ľӿ�,ͳһ�� GameFacade��ʵ�����Լ�����
/// </summary>
public abstract class IGameSystem {

    protected GameFacade m_Facade;
    public virtual void Init() {
        m_Facade = GameFacade.Instance;
    }

    public virtual void Update() { }

    public virtual void Release() { }

}