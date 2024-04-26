using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    [SerializeField]
    private CapsuleCollider2D playerCollider;

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
    private float castDistance;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private ScoreController scoreController;

    private PlayerHealth playerHealth;

    //input
    private float verticalInput;
    private float horizontalInput;
    public bool grounded;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }
    void Start()
    {
        playerColl_Size = playerCollider.size;
        playerColl_Offset = playerCollider.offset;
    }

    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        PlayerMovementAnimation(horizontalInput, verticalInput);
        PlayerMovement(horizontalInput, verticalInput);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
    }

    void PlayerMovement(float horizontalInput, float verticalInput)
    {
        Vector2 position = transform.position;
        position.x += horizontalInput * playerSpeed * Time.deltaTime;
        transform.position = position;
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

        //crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            float sizeX = 0.6048745f;       //size x
            float sizeY = 1.363909f;            //size y

            float offX = 0.01174039f;     //Offset X
            float offY = 0.6169545f;           //Offset y

            animator.SetBool("crouch", true);
            playerCollider.size = new Vector2(sizeX, sizeY);
            playerCollider.offset = new Vector2(offX, offY);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
            playerCollider.offset = playerColl_Offset;
            playerCollider.size = playerColl_Size;
        }

        if(!isGrounded())
        {
            animator.SetBool("jump", true);
        }
        else if (isGrounded())
        {
            animator.SetBool("jump", false);
        }
    }

    void Jump()
    {
        if (isGrounded())
        {
            //check is player is in ground and pressed space set jump power & jump
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            grounded = true;
            return true;
        }
        grounded = false;
        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }

    public void GotHurt()
    {
        playerHealth.TakeDamage(1);
    }

    #region Sounds
    
    public void PlayRunSound1()
    {
        SoundManger.Instance.Play(Sounds.run1);
    }
    public void PlayRunSound2()
    {
        SoundManger.Instance.Play(Sounds.run2);
    }

    public void JumpTakeOffSound()
    {
        SoundManger.Instance.Play(Sounds.JumpTakeOff);
    }
    public void JumpLandSound()
    {
        SoundManger.Instance.Play(Sounds.JumpLand);
    }

    #endregion

}
