using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 5f;

    private float horizontalMovement;

    private PlayerAnimation playerAnim;

    [SerializeField] private float normalJumpForce = 5f,doubleJumpForce=5f;

    private float jumpForce = 5f;

    private RaycastHit2D groundCast;
    private BoxCollider2D boxCol2D;

    [SerializeField] private LayerMask groundMask;

    private bool canDoubleJump;
    private bool jumped;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        boxCol2D = GetComponent<BoxCollider2D>();

        canDoubleJump = true;
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw(TagManger.HORIZONTALMOVEMENTAXIS);

        HandleAnimation();

        HandleJumping();
        CheckToDoubleJump();
    }

    private void FixedUpdate()
    {
        HandleMovement();//перемещение персонажа
    }//fix

    private void HandleMovement()
    {
        if (horizontalMovement > 0)//right move
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (horizontalMovement < 0)//left move
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else//dont move
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    void HandleAnimation()
    {
        if (rb.velocity.y == 0f)//if on the ground
        {
            playerAnim.PlayWalk(Mathf.Abs((int)rb.velocity.x));//всегдда позитив
        }

        playerAnim.ChangeFacingDirection((int)rb.velocity.x);//поврот перса

        playerAnim.PlayJumpAndFall((int)rb.velocity.y);
    }
    void HandleJumping()
    {
        if (Input.GetButtonDown(TagManger.JUMPBUTTON))
        {
            if (isGrounded())
            {
                jumpForce = normalJumpForce;
                Jump();
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    jumpForce = doubleJumpForce;
                    Jump();
                }
            }
        }
    }//

    bool isGrounded()
    {
        
        //groundCast = Physics2D.Raycast(boxCol2D.bounds.center, Vector2.down, boxCol2D.bounds.extents.y + 0.03f, groundMask);
        groundCast = Physics2D.BoxCast(boxCol2D.bounds.center, boxCol2D.bounds.size, 0f, Vector2.down, 0.2f, groundMask);
       return groundCast.collider != null;
      
    }

    void Jump()
    {
        //rb.velocity = new Vector2(0f, jumpForce); тоже что и нижний код
        rb.velocity = Vector2.up * jumpForce;
        jumped = true;
    }

    void CheckToDoubleJump()
    {
        if (!canDoubleJump && rb.velocity.y == 0f)
        {
            canDoubleJump = true;
        }
    }

}//class
