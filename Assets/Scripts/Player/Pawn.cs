using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : PlayerController {

    // Declaring our functions
   
    // Start function
    private void Start()
    {
        // Linking to the player controller
        PlayerController.pawn = this;         
    }

    // Checking if the pawn is on the ground
    public virtual void CheckForGrounded()
    {
        Debug.Log("This is the parent function");
    }

    // Move function
    public virtual void Move()
    {
        Debug.Log("This is the parent function");
    }

    // Jump function
    public virtual void Jump()
    {
        Debug.Log("This is the parent function");
    }

    // Attack function
    public virtual void Attack()
    {
        Debug.Log("This is the parent function");
    }
}
