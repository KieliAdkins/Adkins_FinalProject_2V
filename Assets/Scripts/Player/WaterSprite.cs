using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSprite : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Playing Audio
            AudioSource.PlayClipAtPoint(GameManager.water.waterSound, gameObject.transform.position);

            // Add points to total score
            GameManager.water.currentAmount += GameManager.water.perWater;

            // Destroying the game object
            Destroy(gameObject);
        }
    }
}
