using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int health;
    public int healthMax;
    public ParticleSystem _bloodSpray;

    [SerializeField] float _hurtCountdown = 2f;

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
        _bloodSpray.Play();

        UpdateHeartUI();

        if(health <= 0)
        {
            Destroy(this.gameObject);
            GameManager.Instance.Restart();
            SceneManager.LoadScene(0);
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

    //private IEnumerator HurtDelay(float _hurtCountdown)
    //{

    //}

    public void Reset()
    {
        healthMax = health = hearts.Length;
        UpdateHeartUI();
    }

}
