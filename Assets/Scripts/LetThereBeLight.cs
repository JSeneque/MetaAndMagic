using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LetThereBeLight : MonoBehaviour
{
    [SerializeField] GameObject _darkness;
    bool inMine;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (SceneManager.GetActiveScene().name == "Mine")
        {
            inMine = true;
        }
        else
        {
            inMine = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inMine)
        {
            //if (PlayerController.Instance.isCarryingTorch())
            //{
            //    _darkness.SetActive(false);
            //}
            //else
            //{
            //    _darkness.SetActive(true);
            //}
        }
    }
}
