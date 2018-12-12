using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {
    private SceneStateController m_Controller;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        m_Controller = new SceneStateController();
        m_Controller.SetState(new StartState(m_Controller), false);
    }

    private void Update()
    {
        m_Controller.UpdateState();
    }
}
