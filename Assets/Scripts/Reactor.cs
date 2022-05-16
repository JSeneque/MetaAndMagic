using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reactor : MonoBehaviour
{
    [SerializeField] ParticleSystem _effect;
    [SerializeField] GameObject _item;

    public virtual void Remove()
    {
        StartCoroutine(DelayRemovingObject());
        
    }   
    
    public virtual void Effect()
    {
        _effect.Play();
    }

    public virtual void Drop()
    {
        Instantiate(_item, transform.position, Quaternion.identity);
    }

    IEnumerator DelayRemovingObject()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        
        yield return new WaitForSeconds(1.0f);

        Destroy(gameObject);
    }
}
