using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : Reactor
{
    [SerializeField] ParticleSystem _smoke;
    //[SerializeField] bool _lit;
    [SerializeField] ParticleSystem _psEffect;
    [SerializeField] Color _oreColor;
    [SerializeField] Color _leatherColor;
    [SerializeField] Color _crystalColor;
    //private bool _hasCollectedOre;
    //private bool _hasCollectedLeather;
    //private bool _hasCollectedCrystal;

    private Inventory _inventory;


    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();

        if (_animator == null)
        {
            Debug.LogError("Animator is missing");
        }

        _inventory = PlayerController.Instance.GetComponent<Inventory>();
        if (GameManager.Instance._lit)
        {
            _smoke.Play();
            _animator.SetBool("Lit", true);
        }
            
    }



    public void LightFurnace()
    {
        _smoke.Play();
        _animator.SetBool("Lit", true);
        GameManager.Instance._lit = true;
    }

    public override void Remove()
    {
        base.Remove();
    }

    public override void Effect()
    {
        base.Effect();
    }

    public override void Drop()
    {
        if (GameManager.Instance._lit && GameManager.Instance._hasCollectedOre && GameManager.Instance._hasCollectedLeather && GameManager.Instance._hasCollectedCrystal)
        {
            base.Drop();
        }
    }

    public override void Change(string name)
    {
        base.Change(name);
    }

    public override void Interact(string tag)
    {
        if (GameManager.Instance._lit || tag == "TorchButton")
        {
            switch (tag)
            {
                case "OreButton":
                    var main = _psEffect.main;
                    main.startColor = _oreColor;
                    _psEffect.Play();
                    RemoveFromInventory(tag);
                    GameManager.Instance._hasCollectedOre = true;
                    break;
                case "LeatherButton":
                    main = _psEffect.main;
                    main.startColor = _leatherColor;
                    _psEffect.Play();
                    RemoveFromInventory(tag);
                    GameManager.Instance._hasCollectedLeather = true;
                    break;
                case "CrystalButton":
                    main = _psEffect.main;
                    main.startColor = _crystalColor;
                    _psEffect.Play();
                    RemoveFromInventory(tag);
                    GameManager.Instance._hasCollectedCrystal = true;
                    break;
                case "TorchButton":
                    LightFurnace();
                    break;
                default:
                    break;
            }
        }
    }

    private void RemoveFromInventory(string tag)
    {
        for (int i = 0; i < _inventory.slots.Length; i++)
        {
            if (_inventory.isFull[i])
            {
                var checkItem = _inventory.slots[i].transform.GetChild(0);
                // check if stick
                if (checkItem.gameObject.CompareTag(tag))
                {
                    Destroy(checkItem.gameObject);
                    break;
                }
            }
        }
    }


}
