using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
                inventory.isFull[i] = false;
        }

        if (transform.childCount > 0)
        {
            inventory.isFull[i] = true;
        }
    }
    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            if (child.gameObject.CompareTag("TorchButton"))
            {
                //PlayerController.Instance.GetComponent<PlayerController>().UpdateCarryingTorch(false);
            }
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
