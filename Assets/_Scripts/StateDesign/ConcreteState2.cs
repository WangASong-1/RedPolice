
using System;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteState2 : IState {

    public Context m_Context;

    /// <summary>
    /// @param context
    /// </summary>
    public ConcreteState2(Context context) {
        // TODO implement here
        m_Context = context;
    }

    /// <summary>
    /// @param arg
    /// </summary>
    public void Handl(int arg) {
        // TODO implement here
        if (arg > 10)
        {
            m_Context.SetState(new ConcreteState1(m_Context));
            Debug.Log("ÇÐ»»ÖÁ 1×´Ì¬");
        }
    }

}