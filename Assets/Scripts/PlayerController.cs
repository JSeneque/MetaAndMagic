using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    public Sprite slimeImg;
    public Sprite playerImg;
    public float effectTimer = 20.0f;
    public float timer = 0f;
    public bool isEffected = false;
    public GameObject effect;
    public float effectOffset = -0.629f;
    

    public bool canMove = true;

    public static PlayerController instance;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        instance = this;
        renderer = GetComponent<SpriteRenderer>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (isEffected)
        {
            timer += Time.deltaTime;
            if (timer > effectTimer)
            {
                timer = 0f;
                Vector2 playerPos = new Vector2(transform.position.x, transform.position.y + effectOffset);
                Instantiate(effect, playerPos, Quaternion.identity);
                renderer.sprite = playerImg;
                isEffected = false;
            }
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void TransformToSlime()
    {
        renderer.sprite = slimeImg;
        isEffected = true;

    }

    
}
