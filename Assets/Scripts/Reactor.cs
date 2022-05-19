using System.Collections;
using UnityEngine;

public abstract class Reactor : MonoBehaviour
{
    [SerializeField] ParticleSystem _effect;
    [SerializeField] GameObject _item;
    [SerializeField] GameObject _button;
    [SerializeField] bool _canRemove = true;
    [SerializeField] Transform _dropSpot;

    private Inventory _inventory;

    void Start() => _inventory = PlayerController.Instance.GetComponent<Inventory>();

    public virtual void Remove()
    {
        if (_canRemove)
        {
            StartCoroutine(DelayRemovingObject());
        }
    }

    public virtual void Effect()
    {
        if (_effect != null)
        {
            _effect.Play();
        }
    }

    public virtual void Drop()
    {
        // this is just a workaround to replace stick with torch
        if (_item != null)
        {
            if (_item.name == "Torch")
            {
                for (int i = 0; i < _inventory.slots.Length; i++)
                {
                    if (_inventory.isFull[i])
                    {
                        var checkItem = _inventory.slots[i].transform.GetChild(0);
                        // check if stick
                        if (checkItem.gameObject.CompareTag("StickButton"))
                        {
                            Destroy(checkItem.gameObject);
                            break;
                        }
                    }
                }
            }
            Instantiate(_item, _dropSpot == null ? PlayerController.Instance.gameObject.transform.position : _dropSpot.position, Quaternion.identity);
        }
        
    }

    IEnumerator DelayRemovingObject()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(1.0f);

        Destroy(gameObject);
    }

    public virtual void Change(string name)
    {
        if (_button != null)
        {
            // access to the inventory
            var _inventory = PlayerController.Instance.GetComponent<Inventory>();
            // find the slot with the original button
            for (int i = 0; i < _inventory.slots.Length; i++)
            {
                if (!_inventory.isFull[i])
                {
                    // add item
                    _inventory.isFull[i] = true;
                    Instantiate(_button, _inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
            // replace the button with new button
        }
    }

    public virtual void Interact(string tag)
    {
        
    }
}
