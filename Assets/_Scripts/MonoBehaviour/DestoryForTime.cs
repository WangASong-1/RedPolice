using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class DestroyForTime:MonoBehaviour
{
    public float time = 1;

    private void Start()
    {
        Invoke("Destroy", time);
    }

    private void Destroy()
    {
        DestroyImmediate(this.gameObject);
    }
}

