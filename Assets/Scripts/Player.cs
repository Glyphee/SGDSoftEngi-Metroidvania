using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public Animator playerAnimator;

    private Rigidbody2D rb2D;

    public GameObject gameOver;

    public Text healthText;

    private int playerHealth;

    [SerializeField] private bool isGrounded = false;
    [SerializeField] public BoxCollider2D groundCheck;
    [SerializeField] private bool dblJumpUsed = false;
    [SerializeField] private float jumpForce = 6f;
    public Vector3 playerScale;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerScale = transform.localScale;
        gameOver.SetActive(false);
        playerHealth = 10;
        GameOver();
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            gameOver.SetActive(true);
        }
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

    void CheckForHealthPoints()
    {
        if (playerHealth <= 0)
        {
            gameOver.SetActive(true);
        }
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
        gameOver.SetActive(false);
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

    void GameOver()
    {
        healthText.text = "Health: " + playerHealth.ToString();
        if (playerHealth <= 0)
        {
            gameOver.SetActive(true);
        }
    }
}
