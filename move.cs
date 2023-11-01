using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    float movementSpeed = 4f; //declare the speed at which the capsule moves
    float jumpHeight = 4f; //declare the height of a player's jump
    Rigidbody playerRB; //declare the variable for player's rigidbody component

    void Start() //everything here happens only on the first frame
    {
        playerRB = GetComponent<Rigidbody>(); //playerRB now gets the the player's rigidbody component whenever it's used
    }

    void Update() //everything here happens every frame
    {
        MakeMeMove(); //calls the movement function
        MakeMeJump(); //calls the jump function
    }

    void MakeMeMove() //movement function
    {
        float horiMovement = Input.GetAxis("Horizontal"); //horiMovement will now check for input relating to the horizontal axis(left, right, A, D)
        float vertMovement = Input.GetAxis("Vertical"); //horiMovement will now check for input relating to the vertical axis(up, down, W, S)

        transform.Translate(horiMovement * Time.deltaTime * movementSpeed, 0, 0); //if the horizontal input is pressed, move the player along the X-axis at the speed of movementSpeed
        transform.Translate(0, 0, vertMovement * Time.deltaTime * movementSpeed); //if the vertical input is pressed, move the player along the Z-axis at the speed of movementSpeed
        //for both of these, Time.deltaTime makes sure the speed at which they move is consistent across all PCs/Monitors with different framerates
    }

    void MakeMeJump() //jump function
    {
        if (Input.GetButtonDown("Jump")) //checks for input relating to jumping (Space)
        {
            playerRB.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse); //creates a vertical impulse on the player's rigidbody if the Jump button is pressed. this impulse's strength is based on jumpHeight's value
        }
    }
}
