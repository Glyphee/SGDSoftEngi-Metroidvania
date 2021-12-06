using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator playerAnimator;
    public BoxCollider2D groundCheck;

    public GameObject roadBlock;
    public GameObject gameOver;
    public GameObject unlockablesPanel;
    public Text unlockablesText;

    [SerializeField] private float playerSpeed;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool dblJumpUsed = false;
    [SerializeField] private bool dblJumpUnlocked = false;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private Vector3 playerScale;

    // Start is called before the first frame update
    void Start()
    {
        playerScale = transform.localScale;
        gameOver.SetActive(false);
        unlockablesPanel.SetActive(false);
        roadBlock.SetActive(true);
    }

    // Update is called once per frame
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
        if (other.gameObject.CompareTag("Finish"))
        {

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
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            playerAnimator.SetBool("isJumping", true);
        }
        if(Input.GetButtonDown("Jump") && isGrounded == false && dblJumpUsed == false && dblJumpUnlocked == true)
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
}
