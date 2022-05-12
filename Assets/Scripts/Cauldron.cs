using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public GameObject potion;
    private Animator animator;
    private SpriteRenderer sr;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void PopOutPotion()
    {
        Vector2 pos = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f);
        Instantiate(potion, pos, Quaternion.identity);
        animator.SetBool("brewing", false);
    }
 
    public void Brew()
    {
        animator.SetBool("brewing", true);
    }

    public void SetColour(Color colour)
    {
        sr.color = colour;
    }
}
