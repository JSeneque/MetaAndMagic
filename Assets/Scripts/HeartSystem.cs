using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int health;
    public int healthMax;

    private void Start()
    {
        healthMax =  health = hearts.Length;
    }

    void UpdateHeartUI ()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if ( i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateHeartUI();

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Heal(int amount)
    {
        if (health + amount > healthMax)
        {
            health = healthMax;
        } else
        {
            health += amount;
        }

        UpdateHeartUI();
    }

}
