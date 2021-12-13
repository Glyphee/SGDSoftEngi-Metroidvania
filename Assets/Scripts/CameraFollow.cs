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

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public float yOffSet = 2f;
    public Transform player; 

    // Updates the current location of the camera based on the position of the player
    void Update()
    {
        Vector3 newPos = new Vector3(player.position.x, player.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
