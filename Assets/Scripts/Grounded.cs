using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private int collisionCount = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            collisionCount++;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            collisionCount--;
        }
    }

    private void Update()
    {
        if (collisionCount == 0)
        {
            transform.parent.GetComponent<Player>().GroundCheck(false);
        }
        else
        {
            transform.parent.GetComponent<Player>().GroundCheck(true);
        }
    }
}
