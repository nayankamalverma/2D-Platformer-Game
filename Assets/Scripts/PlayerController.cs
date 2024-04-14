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
    void Start()
    {
        playerColl_Size = playerCollider.size;
        playerColl_Offset = playerCollider.offset;
        rd = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        PlayerMovementAnimation(horizontalInput, verticalInput);
        PlayerMovement(horizontalInput, verticalInput);
    }

    void PlayerMovement(float horizontalInput, float verticalInput)
    {
        //horizontal movement
        Vector2 position = transform.position;
        position.x += horizontalInput * playerSpeed * Time.deltaTime;
        transform.position = position;

        //vertcal movement
        if (verticalInput > 0)
        {
            rd.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
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
            float sizeY = 1.49f;            //size y

            float offX = 0.01174039f;     //Offset X
            float offY = 0.68f;           //Offset y

            animator.SetBool("crouch", true);
            playerCollider.size = new Vector2(sizeX, sizeY);
            playerCollider.offset = new Vector2(offX, offY);

        }else if (Input.GetKeyUp(KeyCode.LeftControl)){
            animator.SetBool("crouch", false);
            playerCollider.offset = playerColl_Offset;
            playerCollider.size = playerColl_Size;
        }

        //jump
        if (verticalInput > 0)
        {
            animator.SetBool("jump", true);
        }else
        {
            animator.SetBool("jump", false);
        }
    }
}
