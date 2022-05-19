using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private ParticleSystem _psEffect;

    void Start() => _psEffect = gameObject.GetComponentInChildren<ParticleSystem>();


}
