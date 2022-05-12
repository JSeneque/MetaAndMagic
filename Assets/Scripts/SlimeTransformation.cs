using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeTransformation : MonoBehaviour
{
    private GameObject player;
    public float offset = -0.629f;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.instance.gameObject;
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y + offset);
        player.GetComponent<PlayerController>().TransformToSlime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
