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

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadNextLevel(string name)
    {
        // last minute workaround to redisplay UI
        GameManager.Instance.EnableUI();

        StartCoroutine(LoadLevelByName(name));
    }



    IEnumerator LoadLevel(int sceneID)
    {
        _animator.SetTrigger("Start");
        //_pressButton.Play();
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(sceneID);
    }

    IEnumerator LoadLevelByName(string name)
    {
        _animator.SetTrigger("Start");
        //_pressButton.Play();
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(name);
    }
}
