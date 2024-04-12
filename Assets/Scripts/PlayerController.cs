using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private BoxCollider2D playerCollider;
    // Start is called before the first frame update

    private Vector2 playerColl_Size;//for storing initial size of collider
    private Vector2 playerColl_Offset;//for storing initial offset of collider
    void Start()
    {
        playerColl_Size = playerCollider.size;
        playerColl_Offset = playerCollider.offset;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        VerticalMovement();
    }

    void HorizontalMovement()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        //move left
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    void VerticalMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            float sizeX = 0.6048745f;       //size x
            float sizeY = 1.49f;            //size y

            float offX = 0.01174039f;     //Offset X
            float offY = 0.68f;           //Offset y

            animator.SetBool("crouch", true);
            playerCollider.size = new Vector2(sizeX, sizeY);   
            playerCollider.offset = new Vector2(offX, offY);

        }else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
            playerCollider.offset = playerColl_Offset;
            playerCollider.size = playerColl_Size; 
        }
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0) { 
            animator.SetBool("jump",true);
        }else if (verticalInput < 0)
        {
            animator.SetBool("jump",false);
        }
    }
}
