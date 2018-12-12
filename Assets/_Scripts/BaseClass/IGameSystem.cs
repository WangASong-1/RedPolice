
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 定义管理类的接口,统一在 GameFacade中实例化以及管理
/// </summary>
public abstract class IGameSystem {

    protected GameFacade m_Facade;
    public virtual void Init() {
        m_Facade = GameFacade.Instance;
    }

    public virtual void Update() { }

    public virtual void Release() { }

}