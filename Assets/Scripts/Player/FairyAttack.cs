using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyAttack : MonoBehaviour {

    // Declaring our variables
    public float moveSpeed;
    public float lifeSpan;
    private Transform tf;  

    // Use this for initialization
    void Start()
    {
        // Acquiring component for movement
        tf = GetComponent<Transform>();
    }

    private void Update()
    {
        if (PlayerController.fairy.isGoingLeft == false)
        {
            // Changing the position of the Game Object
            tf.position = tf.position + (Vector3.right * moveSpeed * Time.deltaTime);

            // Destroying the bullet overtime
            Destroy(gameObject, lifeSpan);
        }

        if (PlayerController.fairy.isGoingLeft == true)
        {
            // Changing the position of the Game Object
            tf.position = tf.position + (Vector3.left * moveSpeed * Time.deltaTime);

            // Destroying the bullet overtime
            Destroy(gameObject, lifeSpan);
        }
    }
   
}
