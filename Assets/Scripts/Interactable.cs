using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject effect;
    protected GameObject player;

    protected virtual void Awake()
    {
        player = PlayerController.instance.gameObject;
    }
    public virtual void Use()
    {
        Destroy(gameObject);
    }
}
