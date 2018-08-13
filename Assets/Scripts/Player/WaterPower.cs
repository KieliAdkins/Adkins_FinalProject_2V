using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPower : MonoBehaviour {

    // Declaring our variables
    public float fullWater;
    public float currentAmount;
    public float startingWater;
    public float perWater;
    public AudioClip waterSound;
    public Slider waterSlider;

    // Use this for initialization
    void Start()
    {
        // Linking to the game manager
        GameManager.water = this;

        // Set the initial health of the player.
        currentAmount = startingWater;

        // Setting the health slider value
        waterSlider.value = startingWater;
    }

    // Update is called once per frame
    void Update()
    {

        // Setting the health slider value
        waterSlider.value = currentAmount;

        // If you have collected enough venom
        if (currentAmount >= fullWater)
        {
            // Setting the boolean to true 
            PlayerController.fairy.waterPowerActive = true;
        }
    }
}
