using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnFairy : Pawn {
    // Declaring our variables
    private Transform tf;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator an;

    public float moveSpeed;
    public float jumpForce;
    public int jumpNumber;
    public int jumpLimit;
    public bool isGrounded;
    public int groundedDistance;

    public bool spiderPowerActive = false;
    public bool waterPowerActive = false;

    public GameObject fairyAttack;
    public Transform rightAttackSpawn;
    public Transform leftAttackSpawn; 

    public GameObject spiderAttack;
    public GameObject waterAttack; 
   
    public bool pawnMove = false;
    public bool characterJump = false; 
    public bool isGoingLeft = false;

    // Use this for initialization
    void Start () {
        // Linking to player controller
        PlayerController.fairy = this;

        // Capturing our transform
        tf = GetComponent<Transform>();

        // Capturing our sprite renderer
        sr = GetComponent<SpriteRenderer>();

        // Capturing our rigidbody
        rb = GetComponent<Rigidbody2D>();

        // Capturing our sprite renderer
        an = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        // Check for grounded function
        CheckForGrounded();
        
        // Move function
        Move(); 
	}

    // Move function
    public override void Move()
    {
        if (characterJump == true)
        {
            // Play animation
            an.Play("Jump");

        }

        if (characterJump == false)
        {
            // If the pawn is moving
            if (pawnMove == true)
            {
                // Playing the animation
                an.Play("Walk");
            }

            // Otherwise
            if (pawnMove == false)
            {
                // Playing the animation
                an.Play("Idle");

            }
        }

        // Moving the character right
        if (Input.GetKey(KeyCode.D))
        {
            // Moving the character's transform
            tf.position = tf.position + (Vector3.right * moveSpeed * Time.deltaTime);

            // Setting the boolean to true for movement
            pawnMove = true;

            // Flipping the character
            sr.flipX = false;

            // Changing the movement direction
            isGoingLeft = false;            
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            pawnMove = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Moving the character's transform
            tf.position = tf.position + (-Vector3.right * moveSpeed * Time.deltaTime);

            // Flipping the character
            sr.flipX = true;

            // Setting the boolean to true for movement
            pawnMove = true;

            // Changing the movement direction
            isGoingLeft = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            pawnMove = false;
        }

        //// If we are on the ground allow player to jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Calling the jump function
            fairy.Jump();                       
        }

        // Telling the pawn to attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Calling the attack function
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.E) && spiderPowerActive == true)
        {
            if (PlayerController.fairy.isGoingLeft == false)
            {
                // Attack instantiation
                GameObject mySpiderAttack = Instantiate(spiderAttack, rightAttackSpawn.position, rightAttackSpawn.rotation) as GameObject;
            }

            if (PlayerController.fairy.isGoingLeft == true)
            {
                // Attack instantiation
                GameObject mySpiderAttack = Instantiate(spiderAttack, leftAttackSpawn.position, leftAttackSpawn.rotation) as GameObject;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && waterPowerActive == true)
        {
            if (PlayerController.fairy.isGoingLeft == false)
            {
                // Attack instantiation
                GameObject myWaterAttack = Instantiate(waterAttack, rightAttackSpawn.position, rightAttackSpawn.rotation) as GameObject;
            }

            if (PlayerController.fairy.isGoingLeft == true)
            {
                // Attack instantiation
                GameObject myWaterAttack = Instantiate(waterAttack, leftAttackSpawn.position, leftAttackSpawn.rotation) as GameObject;
            }
           
        }
    }

    // Check for grounded function
    public override void CheckForGrounded()
    {
        // Variable to hold our about raycast hit
        RaycastHit2D hitInfo;

        // Casting our raycast
        hitInfo = Physics2D.Raycast(transform.position, Vector2.down, groundedDistance);

        // Checking if we hit "ground"
        if (hitInfo.collider != null)
        {
            // if it is set our variable
            if (hitInfo.collider.gameObject.tag == "Ground")
            {
                isGrounded = true;


                // Setting the boolean
                characterJump = false;
            }

            // else set variable false
            else
            {
                isGrounded = false;
                
                // Setting the boolean
                characterJump = true;
            }
        }

        else
        {
            isGrounded = false;

            // Setting the boolean
            characterJump = true;
        }
    }

    // Jump function
    public override void Jump()
    {

        
        if (isGrounded == true)
        {
            // Adding the jump force
            rb.AddForce(Vector2.up * jumpForce);
           
            // Reseting the jump number
            jumpNumber = 0; 
            
        }

        if (isGrounded == false && jumpNumber <= jumpLimit)
        {
            
            // Subtracting from the jump number
            jumpNumber += 1;
           
            // Adding the jump force
            rb.AddForce(Vector2.up * jumpForce);

            // Setting the boolean
            pawnMove = false;
        }
        
    }

    // Attack function
    public override void Attack()
    {
        if (PlayerController.fairy.isGoingLeft == false)
        {
            // Attack instantiation
            GameObject myAttack = Instantiate(fairyAttack, rightAttackSpawn.position, rightAttackSpawn.rotation) as GameObject;
        }

        if (PlayerController.fairy.isGoingLeft == true)
        {
            // Attack instantiation
            GameObject myAttack = Instantiate(fairyAttack, leftAttackSpawn.position, leftAttackSpawn.rotation) as GameObject;
        }
       
    }
}