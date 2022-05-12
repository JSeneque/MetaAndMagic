using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public float fireRate = 1f;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public GameObject projectilePrefab;

    private Animator animator;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        CheckAttackDistance();
    }

    void CheckDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= chaseRadius && distance > attackRadius && !target.gameObject.GetComponent<PlayerController>().isEffected)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            animator.SetBool("moving", true);
        } 
        //else
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, homePosition.position, moveSpeed * Time.deltaTime);
            
        //}
    }

    private void OnDrawGizmos()
    {
        // Display the chase radius when selected
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        // Display the attack radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    void CheckAttackDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= chaseRadius && !target.gameObject.GetComponent<PlayerController>().isEffected)
        {
            timer += Time.deltaTime;

            if (timer >= fireRate)
            {
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
    }
}
