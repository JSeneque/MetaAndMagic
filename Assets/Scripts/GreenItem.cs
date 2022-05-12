using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenItem : Interactable
{
    public float offset = -0.629f;
    public override void Use()
    {
        base.Use();

        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y + offset);
        Instantiate(effect, playerPos, Quaternion.identity);
        player.GetComponent<PlayerController>().TransformToSlime();
    }
}
