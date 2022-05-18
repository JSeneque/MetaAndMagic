using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private HeartSystem _playerHealth;

    private void Start()
    {
        // get a reference to player
        _playerHealth = PlayerController.Instance.GetComponent<HeartSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _playerHealth.TakeDamage(1);
        }
    }
}
