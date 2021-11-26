using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Platform"))
        {
            transform.parent.GetComponent<Player>().GroundCheck(true);
            print("grounded");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            transform.parent.GetComponent<Player>().GroundCheck(false);
            print("in air");
        }
    }
}
