using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EnemyHealth : MonoBehaviour {

    // Declaring our variables
   
    // Health information
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    public AudioClip deathSound;
    public int pointWorth;

    // Use this for initialization
    void Start () {
        // Setting this as the script
        EnemyController.eHealth = this; 

        // Set the initial health of the player.
        currentHealth = startingHealth;

        // Setting the health slider value
        healthSlider.value = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
        // Setting the health slider value
        healthSlider.value = currentHealth;

        // If player has no health 
        if (currentHealth == 0)
        {
            // Adding points to player
            GameManager.score.playerScore += pointWorth;

            // Playing the audio
            AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);

            // Destroying the enemy
            Destroy(gameObject);
        }
    }
}
