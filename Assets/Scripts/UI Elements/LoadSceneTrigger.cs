using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour {

    // Declaring our variables
    public int sceneNumber; 

    // On trigger enter function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Loading our scene
        SceneManager.LoadScene(sceneNumber);
    }
}
