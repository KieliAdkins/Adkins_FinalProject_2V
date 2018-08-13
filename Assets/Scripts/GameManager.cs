using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Defining our variables
    public static Score score;
    public static GameManager instance;
    public static SpiderPower spider;
    public static WaterPower water;
    
    // Use this for initialization and destruction of duplicate Game Managers
    void Awake()
    {
        // Ensuring that the Game manager is loaded
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Ensuring that the Game manager is not overwritten
        else
        {
            Destroy(this.gameObject);
        }
    }
}
