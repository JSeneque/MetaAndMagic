using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private float _transitionTime = 1f;
    //[SerializeField] private AudioSource _pressButton;
     
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Missing the animator for level transitions");
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    LoadNextLevel();
        //}
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int leveIndex)
    {
        _animator.SetTrigger("Start");
        //_pressButton.Play();
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(leveIndex);
    }
}
