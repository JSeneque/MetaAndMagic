using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 0.5f);
        GameObject obj = Instantiate(item, playerPos, Quaternion.identity);
        WorldItemManager.Instance.DropItem(obj);
    }
}
