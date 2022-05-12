using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime = 3f;

    private PlayerController player;
    private Vector3 playerPos;
    private PlayerManager playerManager;
    private Animator camAnim;

    
    // Start is called before the first frame update
    void Start()
    {
        playerPos = PlayerController.instance.transform.position;
        playerManager = PlayerManager.instance;
        player = PlayerController.instance;
        camAnim = Camera.main.GetComponent<Animator>();
    }

    private void Update()
    {
        CheckLifeTime();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }

    void CheckLifeTime()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            camAnim.ResetTrigger("shake");
            camAnim.SetTrigger("shake");
            player.gameObject.GetComponent<HeartSystem>().TakeDamage(1);
        }
    }
}
