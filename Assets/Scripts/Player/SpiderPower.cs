using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderPower : MonoBehaviour {

    // Declaring our variables
    public float fullSpider;
    public float currentAmount;
    public float startingVenom; 
    public float perVenom;
    public AudioClip spiderSound;
    public Slider spiderSlider; 

	// Use this for initialization
	void Start () {
        // Linking to the game manager
        GameManager.spider = this;

        // Set the initial health of the player.
        currentAmount = startingVenom;

        // Setting the health slider value
        spiderSlider.value = startingVenom;
    }
	
	// Update is called once per frame
	void Update () {

        // Setting the health slider value
        spiderSlider.value = currentAmount;

        // If you have collected enough venom
        if (currentAmount >= fullSpider)
        {
            // Setting the boolean to true 
            PlayerController.fairy.spiderPowerActive = true;
           
        }
    }
}
