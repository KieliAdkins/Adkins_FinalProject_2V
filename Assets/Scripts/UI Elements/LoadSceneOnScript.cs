using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnScript : MonoBehaviour {

    // Declaring the load index function
    public void LoadByIndex(int sceneIndex)
    {
        // Calling the scene manager
        SceneManager.LoadScene(sceneIndex); 
    }
}
