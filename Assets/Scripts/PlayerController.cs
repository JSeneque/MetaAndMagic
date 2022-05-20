using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    //public Sprite slimeImg;
    //public Sprite playerImg;
    //public float effectTimer = 20.0f;
    //public float timer = 0f;
    //public bool isEffected = false;
    //public GameObject effect;
    //public float effectOffset = -0.629f;

    struct ScenePositions
    {
        int SceneID;
        Transform Position;
    }
    

    public bool canMove = true;

    public static PlayerController Instance;

    private Vector3 _change;
    private Rigidbody2D rb;
    private Dictionary<int, ScenePositions> _scenePositions = new Dictionary<int, ScenePositions>();

    //private Vector2 moveVelocity;
    //private SpriteRenderer renderer;
    private Animator _animator;
    // Start is called before the first frame update

    private Inventory _inventory;
    private GameObject _uIInventory;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        _inventory = PlayerController.Instance.GetComponent<Inventory>();
        _uIInventory = GameObject.FindGameObjectWithTag("UIInventory");
        int pos = 0;
        for (int i = 0; i < _uIInventory.transform.childCount; i++)
        {
            var child = _uIInventory.transform.GetChild(i);
            if (child.CompareTag("Slot"))
            {
                _inventory.slots[pos] = child.gameObject;
                pos++;
            }
        }

        SessionData.Instance.SetStartTime();
    }

    // Update is called once per frame
    void Update()
    {
        //if (canMove)
        //{
        //Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Debug.Log(moveInput);

        //if (moveInput != Vector2.zero)
        //{
        //    moveVelocity = moveInput.normalized * speed;
        //    _animator.SetFloat("moveX", moveInput.x);
        //    _animator.SetFloat("moveY", moveInput.y);
        //    _animator.SetBool("moving", true);
        //} else
        //{
        //    _animator.SetBool("moving", false);
        //    moveVelocity = Vector2.zero;
        //}
        if (canMove)
        {
            _change = Vector3.zero;
            _change.x = Input.GetAxisRaw("Horizontal");
            _change.y = Input.GetAxisRaw("Vertical");

            //Debug.Log(_change);

            if (_change != Vector3.zero)
            {
                MoveCharacter();
                _animator.SetFloat("moveX", _change.x);
                _animator.SetFloat("moveY", _change.y);
                _animator.SetBool("moving", true);
            }
            else
            {
                _animator.SetBool("moving", false);
            }
        }



        //}
        //else
        //{
        //    rb.velocity = Vector2.zero;
        //}

        //if (isEffected)
        //{
        //    timer += Time.deltaTime;
        //    if (timer > effectTimer)
        //    {
        //        timer = 0f;
        //        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y + effectOffset);
        //        Instantiate(effect, playerPos, Quaternion.identity);
        //        renderer.sprite = playerImg;
        //        isEffected = false;
        //    }
        //}

    }

    private void FixedUpdate()
    {
        if (_change != Vector3.zero && canMove)
        {
            MoveCharacter();
        }
    }

    //public void TransformToSlime()
    //{
    //    renderer.sprite = slimeImg;
    //    isEffected = true;
    //}

    void MoveCharacter()
    {
        rb.MovePosition(transform.position + _change * speed * Time.deltaTime);
        //transform.Translate(Vector3.right * _change.x * speed * Time.deltaTime);
        //transform.Translate(Vector3.up * _change.y * speed * Time.deltaTime);
    }

    public void SetScenePosition(int _sceneId, Transform _pos)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Potion"))
        {
            Destroy(other.gameObject);
            _animator.SetBool("Dance", true);
            canMove = false;
            SessionData.Instance.SetEndTime();
            StartCoroutine(EndGame(3));
        }
    }

    IEnumerator EndGame(float delay)
    {
        yield return new WaitForSeconds(delay);

        // reload the current scene
        //UIFade.instance.FadeToBlack();
        GameManager.Instance.WinGame();

    }

    public void ResetPlayer()
    {
        canMove = true;
        _animator.SetBool("Dance", false);
    }

}

