using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float playerSpeed;

    private Rigidbody2D rb2D;

    public bool isGrounded = false;
    public BoxCollider2D groundCheck;
    public bool dblJumpUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
        if(Input.GetButtonDown("Jump") && isGrounded == false && dblJumpUsed == false)
        {
            dblJumpUsed = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            print("dbljumped");
        }
    }

    public void GroundCheck(bool grounded)
    {
        isGrounded = grounded;
    }
}
