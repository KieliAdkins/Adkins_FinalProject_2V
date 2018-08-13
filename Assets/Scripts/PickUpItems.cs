using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour {

    // Declaring our variables
    public float pickUpPoints;
    public AudioClip pickUpSound; 

    // On collision function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking to make sure it is player
        if (collision.gameObject.tag == "Player")
        {
            // Playing Audio
            AudioSource.PlayClipAtPoint(pickUpSound, gameObject.transform.position);

            // Add points to player score
            GameManager.score.playerScore += pickUpPoints;

            // Destroying the GameObject
            Destroy(gameObject);
        }
    }
}
