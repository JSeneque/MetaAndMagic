using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.GetComponent<UIFade>().FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
