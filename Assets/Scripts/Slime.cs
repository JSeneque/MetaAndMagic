using UnityEngine;

public class Slime : Enemy
{
    //public float fireRate = 1f;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    //public GameObject projectilePrefab;

    private Animator animator;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerController.Instance.transform;
        animator = GetComponent<Animator>();

        // create a home position at the starting location
        var homePos = new GameObject("Home Position");
        homePosition = Instantiate(homePos, transform.position, Quaternion.identity).transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        //CheckAttackDistance();
    }

    void CheckDistance()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(target.position, transform.position);

            if (distance <= chaseRadius && distance > attackRadius)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                animator.SetBool("moving", true);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, homePosition.position, moveSpeed * Time.deltaTime);
            }
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HeartSystem>().TakeDamage(1);
        }
    }
}
