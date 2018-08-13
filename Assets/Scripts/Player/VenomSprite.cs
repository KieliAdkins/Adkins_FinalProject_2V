using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomSprite : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Playing Audio
            AudioSource.PlayClipAtPoint(GameManager.spider.spiderSound, gameObject.transform.position);

            // Add points to total score
            GameManager.spider.currentAmount += GameManager.spider.perVenom;

            // Destroying the game object
            Destroy(gameObject);
        }
    }
}
