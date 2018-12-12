
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public abstract class IBaseUI {
    protected GameFacade m_Facade;

    public GameObject m_RootUI;
    public virtual void Init() {
        m_Facade = GameFacade.Instance;
    }

    public virtual void Update() { }

    public virtual void Release() { }

    protected void Show()
    {
        m_RootUI.SetActive(true);
    }
    protected void Hide() {
        m_RootUI.SetActive(false);

    }
}