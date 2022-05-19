using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : Reactor
{
    [SerializeField] ParticleSystem _smoke;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();

        if (_animator == null)
        {
            Debug.LogError("Animator is missing");
        }
    }


    public void LightFurnace()
    {
        _smoke.Play();
        _animator.SetBool("Lit", true);
    }

    public override void Remove()
    {
        base.Remove();
    }

    public override void Effect()
    {
        base.Effect();
        LightFurnace();
    }

    public override void Drop()
    {
        base.Drop();
    }

    public override void Change(string name)
    {
        base.Change(name);
    }
}
