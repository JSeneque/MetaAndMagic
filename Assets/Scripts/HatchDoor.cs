using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchDoor : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        _animator.SetTrigger("Open");
    }
}
