using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadUI : MonoBehaviour
{
    [SerializeField] GameObject _uIHeart;
    [SerializeField] GameObject _uIInventory;
    [SerializeField] GameObject _uiPlayAgain;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start Game");
        _uIHeart.SetActive(true);
        _uIInventory.SetActive(true);
        _uiPlayAgain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
