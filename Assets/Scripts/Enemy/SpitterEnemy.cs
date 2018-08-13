using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterEnemy : MonoBehaviour {

    // Declaring our variables

    // Enemy hit variables
    public AudioClip enemyHit;
    public int healthHit;

    // The amount of damage the character does when hitting the enemy
    public int characterHitPoints;
  
    // Movement variables
    protected Vector3 velocity;
    private Transform tf;
    public float distance;
    public float moveSpeed;
    Vector3 originalPosition;
    bool isGoingLeft = false;
    public float distFromStart;

    private SpriteRenderer sr;
    public Animator an;

    public bool isMoving = false;
    public bool onAttack = false; 

    public void Start()
    {
        // The beginning position of the enemy
        originalPosition = gameObject.transform.position;

        // Capturing the transform
        tf = GetComponent<Transform>();

        // Capturing the sprite renderer
        sr = GetComponent<SpriteRenderer>();

        // Capturing the animator
        an = GetComponent<Animator>();

        // Setting the velocity
        velocity = new Vector3(moveSpeed, 0, 0);

        // Getting the translate
        tf.Translate(velocity.x * Time.deltaTime, 0, 0);

        // Linking to the enemy controller
        EnemyController.spitter = this; 
    }

    void Update()
    {
        // Setting the distance from start
        distFromStart = transform.position.x - originalPosition.x;

        // If the enemy is
        if (isGoingLeft)
        {
            // Setting the movement boolean
            isMoving = true;

            // If gone too far, switch direction
            if (distFromStart < -distance)
                SwitchDirection();

            // Translating the enemy
            tf.Translate(-velocity.x * Time.deltaTime, 0, 0);
        }

        else
        {
            // Setting the movement boolean
            isMoving = true; 

            // If gone too far, switch direction
            if (distFromStart > distance)
                SwitchDirection();

            // Translating the enemy
            tf.Translate(velocity.x * Time.deltaTime, 0, 0);
        }

        // If the enemy is attacking
        if (onAttack == true)
        {
            // Play the animation
            an.Play("Spitter_Attack");
        }

        // If the enemy is not attacking
        if (onAttack == false)
        {
            // If enemy is moving
            if (isMoving == true)
            {
                // Play the animation
                an.Play("Spitter_Walk");
            }

            // Otherwise
            if (isMoving == false)
            {
                // Play the animation
                an.Play("Spitter_Idle");
            }
        }
       
    }

    // Switching direction
    void SwitchDirection()
    {
        // Changing the movement direction
        isGoingLeft = !isGoingLeft;

        // Flipping the direction of the character
        sr.flipX = !sr.flipX;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the collision object is player
        if (collision.gameObject.tag == "Player")
        {
            // Removing the health points
            PlayerHealth.pHealth.currentHealth -= healthHit;

            // Playing the audio
            AudioSource.PlayClipAtPoint(enemyHit, gameObject.transform.position);
        }

        // If the collision object is attack
        if (collision.gameObject.tag == "Attack")
        {
            // Destroying the object
            Destroy(collision.gameObject);

            // Removing enemy health
            EnemyHealth.eHealth.currentHealth -= characterHitPoints;
        }
    }

    // Trigger function
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Setting the attack boolean
            onAttack = true;            
            
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Setting the attack boolean
            onAttack = false;
        }
    }
}
