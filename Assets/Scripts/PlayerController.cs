using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //componets
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private BoxCollider2D playerCollider;
    private Rigidbody2D rd;

    //data to update player
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpForce;
    private Vector2 playerColl_Size;//for storing initial size of collider
    private Vector2 playerColl_Offset;//for storing initial offset of collider
    [SerializeField]
    private Vector2 boxSize;
    [SerializeField]
    private float castDistamce;
    [SerializeField]
    private LayerMask groundLayer;

    //input
    private float verticalInput;
    private float horizontalInput;
    public bool grounded;

    private void Awake()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerColl_Size = playerCollider.size;
        playerColl_Offset = playerCollider.offset;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        PlayerMovementAnimation(horizontalInput, verticalInput);
        PlayerMovement(horizontalInput, verticalInput);

        

    }

    private void FixedUpdate()
    {
        
    }

    void PlayerMovement(float horizontalInput, float verticalInput)
    {
        //horizontal movement
        Vector2 position = transform.position;
        position.x += horizontalInput * playerSpeed * Time.deltaTime;
        transform.position = position;

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            rd.AddForce(new Vector2(rd.velocity.x, jumpForce));
        }


    }
    void PlayerMovementAnimation(float horizontalInput, float verticalInput)
    {
        //horizontal
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        Vector3 scale = transform.localScale;
        //move left
        if (horizontalInput < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontalInput > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //vertical jump and crouch

        if (Input.GetKeyDown(KeyCode.LeftControl)){

            float sizeX = 0.6048745f;       //size x
            float sizeY = 1.363909f;            //size y

            float offX = 0.01174039f;     //Offset X
            float offY = 0.6169545f;           //Offset y

            animator.SetBool("crouch", true);
            playerCollider.size = new Vector2(sizeX, sizeY);
            playerCollider.offset = new Vector2(offX, offY);

        }else if (Input.GetKeyUp(KeyCode.LeftControl)){
            animator.SetBool("crouch", false);
            playerCollider.offset = playerColl_Offset;
            playerCollider.size = playerColl_Size;
        }

        //jump
        if (!isGrounded())
        {
            animator.SetBool("jump", true);
        }else if(isGrounded())
        {
            animator.SetBool("jump", false);
        }
    }

    

    //to check player is on ground or not
    bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0,-transform.up, castDistamce, groundLayer)){ 
            grounded = true;
            return true; }
        grounded = false;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up*castDistamce, boxSize);
    }
}
