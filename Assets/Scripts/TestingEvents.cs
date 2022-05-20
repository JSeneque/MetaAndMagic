using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEvents : MonoBehaviour
{
    public event EventHandler OnSpacePressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TurnOnFurnace()
    {
        OnSpacePressed?.Invoke(this, EventArgs.Empty);
    }

}
