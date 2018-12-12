using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class CampOnClick :MonoBehaviour
{
    private ICamp m_Camp;
    public ICamp Camp { set { m_Camp = value; } }

    private void OnMouseUpAsButton()
    {

        GameFacade.Instance.ShowCampInfo(m_Camp);
    }
}

