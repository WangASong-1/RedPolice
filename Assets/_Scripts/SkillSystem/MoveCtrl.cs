using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCtrl {
    public GameObject m_GameObject;
    public Transform m_Transform;
    public Vector3 m_DeltaPosition;
    public NavMeshAgent m_NavAgent;

    public MoveCtrl(GameObject gameObject)
    {
        m_GameObject = gameObject;
        m_Transform = m_GameObject.transform;
        m_NavAgent = m_GameObject.GetComponent<NavMeshAgent>();
    }
    
    public void AddDeltaPosition(Vector3 vec)
    {
        m_DeltaPosition = vec;
    }

    public void Update()
    {
        if(m_DeltaPosition != Vector3.zero)
        {
            m_Transform.position += m_DeltaPosition;
            m_DeltaPosition = Vector3.zero;
        }
    }
}
