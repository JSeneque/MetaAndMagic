using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    public float endGameDelay = 5.0f;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    // keeps track of or player for other code to reference
    public GameObject player;
    public string endScene;
    public float waitToLoad = 1f;

    private bool isDying;

    public void KillPlayer()
    {
        // need to freeze player input

        //StartCoroutine(PlayerDeath(endGameDelay));
        if (!isDying)
        {
            isDying = true;
            player.GetComponent<PlayerController>().canMove = false;
            StartCoroutine(PlayerDeath(endGameDelay));
        }

    }

    IEnumerator PlayerDeath(float delay)
    {
        Debug.Log("player death");
        yield return new WaitForSeconds(delay);

        // reload the current scene
        //UIFade.instance.FadeToBlack();
        SceneManager.LoadScene(endScene);
    }
}
