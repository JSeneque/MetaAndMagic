using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public string loadScene;
    public string winScene;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        


        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadScene);
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName)
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

}
