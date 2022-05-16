using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;


    public void OnDie()
    {
        ps.Play();
        Debug.Log("Cow Effect!");
    }
}
