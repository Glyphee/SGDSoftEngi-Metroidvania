using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator playerAnimator;
    public BoxCollider2D groundCheck;

    [SerializeField] GameObject roadBlock;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject unlockablesPanel;
    [SerializeField] GameObject winScreen;

    [SerializeField] Text unlockablesText;

    public Transform wallGrabPoint;
    public LayerMask whatIsGround;
    public Rigidbody2D rb2D;

    [SerializeField] private float playerSpeed;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool dblJumpUsed = false;
    [SerializeField] private bool dblJumpUnlocked = false;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private Vector3 playerScale;
    private bool canGrab, isGrabbing;
    private float gravityStore;
    [SerializeField] private bool wallJumpUnlocked = false;

    void Start()
    {
        gravityStore = rb2D.gravityScale;
        playerScale = transform.localScale;

        gameOver.SetActive(false);
        unlockablesPanel.SetActive(false);
        roadBlock.SetActive(true);
        winScreen.SetActive(false);

        dblJumpUnlocked = false;
        wallJumpUnlocked = false;
    }

    void Update()
    {
        // Disables movement while the unlockables panel is set to true
        if (!unlockablesPanel.activeInHierarchy)
        {
            Jump();

            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * playerSpeed;
        }

        //Sets dblJumpUsed back to false once the player hits the ground
        if (isGrounded)
        {
            dblJumpUsed = false;
        }

        // Lets the animator display the correct animations for movement
        if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {    
            playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }

        WallJumping();

        //Detects movement direction
        FlipSprite();

        // Hides the unlockables panel by pressing enter
        if (unlockablesPanel.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                unlockablesPanel.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            gameOver.SetActive(true);
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            winScreen.SetActive(true);
        }

        if (other.gameObject.CompareTag("AbilityHead0"))
        {
            if(!dblJumpUnlocked)
            {
                dblJumpUnlocked = true;
                unlockablesPanel.SetActive(true);
                unlockablesText.text = "Congratulations! You unlocked double jumping!";
            }
        }

        if (other.gameObject.CompareTag("AbilityHead1"))
        {
            if(roadBlock.activeInHierarchy)
            {
                roadBlock.SetActive(false);
                unlockablesPanel.SetActive(true);
                unlockablesText.text = "The path is now unblocked!";
            }
        }

        if (other.gameObject.CompareTag("AbilityHead2"))
        {
            if (!wallJumpUnlocked)
            {
                wallJumpUnlocked = true;
                unlockablesPanel.SetActive(true);
                unlockablesText.text = "Congratulations! You unlocked wall jumping!";
            }
        }
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            playerAnimator.SetBool("isJumping", true);
        }
        if(Input.GetButtonDown("Jump") && isGrounded == false && dblJumpUsed == false && dblJumpUnlocked)
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

    private void FlipSprite()
    {
        if (Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerScale.x = 5;
        }
        else if (Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerScale.x = -5;
        }
        transform.localScale = playerScale;
    }

    private void WallJumping()
    {
        canGrab = Physics2D.OverlapCircle(wallGrabPoint.position, .2f, whatIsGround);

        isGrabbing = false;

        if (canGrab && !isGrounded && wallJumpUnlocked)
        {
            if (playerScale.x == 5 && Input.GetAxisRaw("Horizontal") > 0 || playerScale.x == -5 && Input.GetAxisRaw("Horizontal") < 0)
            {
                isGrabbing = true;
            }
        }

        if(isGrabbing)
        {
            rb2D.gravityScale = 0f;
            rb2D.velocity = Vector2.zero;
            isGrabbing = false;
            dblJumpUsed = false;
        }
        else
        {
            rb2D.gravityScale = gravityStore;
        }
    }
}
