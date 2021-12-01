using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public Animator playerAnimator;

    private Rigidbody2D rb2D;


    [SerializeField] private bool isGrounded = false;
    [SerializeField] public BoxCollider2D groundCheck;
    [SerializeField] private bool dblJumpUsed = false;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private float jumpForce = 6f;
    public Vector3 playerScale;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * playerSpeed;
        //Sets dblJumpUsed back to false once the player hits the ground
        if(isGrounded)
        {
            dblJumpUsed = false;
        }
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }
        //Detects movement direction
        FlipSprite();
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            playerAnimator.SetBool("isJumping", true);
        }
        if(Input.GetButtonDown("Jump") && isGrounded == false && dblJumpUsed == false)
        {
            dblJumpUsed = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            print("dbljumped");
        }
    }

    public void GroundCheck(bool grounded)
    {
        isGrounded = grounded;
    }

    void FlipSprite()
    {
        if (Input.GetKeyDown("d"))
        {
            playerScale.x = 5;
        }
        else if (Input.GetKeyDown("a"))
        {
            playerScale.x = -5;
        }
        transform.localScale = playerScale;
    }
}
