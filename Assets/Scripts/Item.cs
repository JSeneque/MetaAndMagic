using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    [SerializeField] string _interactWith;
    public float _dropDistance = 5f;
    public GameObject _dropItem;

    public override void Use()
    {
        Transform player = PlayerController.Instance.transform;
        Vector2 position = new Vector2(player.transform.position.x, player.transform.position.y);

        // do a sphere hit check
        //Collider[] hitColliders = Physics.OverlapSphere(player.position, _dropDistance);
        Collider2D[] hitInfo = Physics2D.OverlapCircleAll(position, _dropDistance);
        {
            foreach(var hit in hitInfo)
            {
                if (hit.gameObject.CompareTag(_interactWith))
                {
                    Debug.Log("Hit " + _interactWith);
                    //Instantiate(effect, hit.gameObject.transform);
                    hit.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    hit.gameObject.GetComponent<Cow>().OnDie();
                }
            }
            
        }
    }


}
