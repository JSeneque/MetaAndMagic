using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject _button;

    private Inventory _inventory;

    void Start() => _inventory = PlayerController.Instance.GetComponent<Inventory>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
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
        }
    }
}
