using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    [SerializeField] GameObject _furnaceFire;
    [SerializeField] ParticleSystem _smoke;

    public void LightFurnace()
    {
        _furnaceFire.SetActive(true);
        _smoke.Play();
    }
}
