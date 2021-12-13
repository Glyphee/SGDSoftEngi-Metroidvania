//////////////////////////////////////////////
//Assignment/Lab/Project: Metroidvania
//Name: Malcolm Coronado, Noah Posey, Bryan Wolstromer
//Section: 2021FA.SGD.285.
//Instructor: Aurore Wold
//Date: 11/10/2021
/////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private int collisionCount = 0;
    public Animator playerAnimator;

    // Tells the game that the player is currently on solid ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Platform"))
        {
            collisionCount++;
        }
    }

    // Tells the game that the player is currently in the air
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Platform"))
        {
            collisionCount--;
        }
    }

    // Displays the correct animation for on the ground or in the air
    private void Update()
    {
        if (collisionCount == 0)
        {
            transform.parent.GetComponent<Player>().GroundCheck(false);
            playerAnimator.SetBool("isGrounded", false);
        }
        else
        {
            transform.parent.GetComponent<Player>().GroundCheck(true);
            playerAnimator.SetBool("isGrounded", true);
            playerAnimator.SetBool("isJumping", false);
        }
    }
}
