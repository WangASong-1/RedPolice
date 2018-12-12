
using System;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteState1 : IState {
    public Context m_Context;

    /// <summary>
    /// @param context
    /// </summary>
    public ConcreteState1(Context context) {
        // TODO implement here
        m_Context = context;
    }

    /// <summary>
    /// @param arg
    /// </summary>
    public void Handl(int arg) {
        if (arg < 10)
        {
            m_Context.SetState(new ConcreteState2(m_Context));
            Debug.Log("ÇÐ»»ÖÁ 2×´Ì¬");
        }
    }

}