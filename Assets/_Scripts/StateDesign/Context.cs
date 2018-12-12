
using System;
using System.Collections.Generic;


public class Context {

    public Context() {
    }

    public IState m_State;



    /// <summary>
    /// @param state
    /// </summary>
    public void SetState(IState state) {
        // TODO implement here
        m_State = state;
    }

    /// <summary>
    /// @param arg
    /// </summary>
    public void Handl(int arg) {
        // TODO implement here
        m_State.Handl(arg);
    }

}