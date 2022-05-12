using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerItem : Interactable
{
    private GameObject cauldron;
    public float dropDistance = 0.5f;
    public GameObject potion;
    public Color brewingColour;

    
    public override void Use()
    {
        Transform player = PlayerController.instance.transform;
        cauldron = GameObject.FindGameObjectWithTag("Cauldron");

        float distance = Vector3.Distance(cauldron.transform.position, player.position);
        

        if ( distance <= dropDistance)
        {
            base.Use();

            cauldron.GetComponent<Cauldron>().SetColour(brewingColour);
            cauldron.GetComponent<Cauldron>().potion = potion;
            cauldron.GetComponent<Cauldron>().Brew();
        }
    }
}
