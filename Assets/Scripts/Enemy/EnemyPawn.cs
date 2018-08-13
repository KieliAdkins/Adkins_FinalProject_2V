using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : EnemyController {

    // Defining our variables
    public float moveSpeed;

    // Start function
    private void Start()
    {
        EnemyController.pawn = this; 
    }

    // Move function
    public virtual void Move()
    {
        Debug.Log("Parent Move");
    }

    // Attack function
    public virtual void Attack()
    {
        Debug.Log("Parent Move");
    }
    
}
