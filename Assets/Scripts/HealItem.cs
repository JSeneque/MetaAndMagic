using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Interactable
{

    public override void Use()
    {
        base.Use();
        Instantiate(effect, player.transform.position, Quaternion.identity);
        player.GetComponent<HeartSystem>().Heal(1);
    }
}
