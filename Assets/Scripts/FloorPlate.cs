using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlate : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] GameObject _hatchDoor;
    [SerializeField] GameObject _sceneTransition;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("Pressed", true);
            _hatchDoor.GetComponent<HatchDoor>().OpenDoor();
            _sceneTransition.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("Pressed", false);
        }
    }
}
