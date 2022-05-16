using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected GameObject effect;

    protected GameObject player;

    protected virtual void Start()
    {
        player = PlayerController.Instance.gameObject;
    }

    public virtual void Use()
    {
        Destroy(gameObject);
    }


}
