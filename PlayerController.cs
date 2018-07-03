using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float activeMoveSpeed;

	public bool canMove;

	public Rigidbody2D myRigidbody;

	public float jumpSpeed;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	public bool isGrounded;

	//private Animator myAnim;

	public Vector3 respawnPosition;

	public LevelManager theLevelManager;

	public GameObject stompBox;

	public float knockbackForce;
	public float knockbackLength;
	private float knockbackCounter;

	public float invincibilityLength;
	private float invincibilityCounter;

	public AudioSource jumpSound;
	public AudioSource hurtSound;

	private bool onPlatform;
	public float onPlatformSpeedModifier;

    public GameObject pistol;
    public GameObject mp5;
    public int whatGun;

    public Transform downstairPosition;
    public Transform upstairPosition;
    public bool takeUpstair;
    public bool takeDownstair;

    Transform playerGraphics;

    //////////////////////// < D A S H >
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private int walkDirection;

    ///////////////////////// </ D A S H >

    void Awake()
    {
        playerGraphics = transform.Find("Graphics");
        if(playerGraphics == null)
        {
            Debug.LogError("There is no 'Graphics' object as a child of the player");
        }
    }
    
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		//myAnim = GetComponent<Animator>();

		respawnPosition = transform.position;

		theLevelManager = FindObjectOfType<LevelManager>();

		activeMoveSpeed = moveSpeed;

		canMove = true;

        takeUpstair = false;
        takeDownstair = false;

        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
	}
	
	// Update is called once per frame
	void Update () {

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if(knockbackCounter <= 0 && canMove)
		{

			if(onPlatform)
			{
				activeMoveSpeed = moveSpeed * onPlatformSpeedModifier;
			} else {
				activeMoveSpeed = moveSpeed;
			}

			if(Input.GetAxisRaw ("Horizontal") > 0f)
			{
				myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f);
				playerGraphics.localScale = new Vector3(1f,1f,1f);
                walkDirection = 2;
			} else if(Input.GetAxisRaw ("Horizontal") < 0f)
			{
				myRigidbody.velocity = new Vector3(-activeMoveSpeed, myRigidbody.velocity.y, 0f);
                playerGraphics.localScale = new Vector3(-1f, 1f, 1f);
                walkDirection = 1;
			} else {
				myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
			}

			if(Input.GetButtonDown ("Jump") && isGrounded)
			{
				myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
				jumpSound.Play();
			}

            if (whatGun == 0)
            {
                pistol.SetActive(true);
                mp5.SetActive(false);
               
            }
                
            if (whatGun == 1)
            {                
                mp5.SetActive(true);
                pistol.SetActive(false);
                
            }
            
				
		}

        if(takeUpstair == true)
        {
            transform.position = new Vector3(downstairPosition.transform.position.x, downstairPosition.transform.position.y, 0);
            takeUpstair = false;
        }

        if(takeDownstair == true)
        {
            transform.position = new Vector3(upstairPosition.transform.position.x, upstairPosition.transform.position.y, 0);
            takeDownstair = false;
        }

		if(knockbackCounter > 0)
		{
			knockbackCounter -= Time.deltaTime;

			if(transform.localScale.x > 0)
			{
				myRigidbody.velocity = new Vector3(-knockbackForce, knockbackForce, 0f);
			} else {
				myRigidbody.velocity = new Vector3(knockbackForce, knockbackForce, 0f);
			}
		}

		if(invincibilityCounter > 0)
		{
			invincibilityCounter -= Time.deltaTime;
		}

		if(invincibilityCounter <= 0)
		{
			theLevelManager.invincible = false;
		}

		//myAnim.SetFloat("Speed", Mathf.Abs( myRigidbody.velocity.x));
		//myAnim.SetBool("Grounded", isGrounded);

		if(myRigidbody.velocity.y < 0)
		{
			stompBox.SetActive(true);
		} else {
			stompBox.SetActive(false);
		}

        //////// D A S H /////////////////////////////////
        if(direction == 0)
        {
            if(Input.GetMouseButtonDown(1))
            {
                if(walkDirection == 1)
                {
                    direction = 1;
                }
                else if(walkDirection == 2)
                {
                    direction = 2;
                }
                
            }
            
        }
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                
            }
            else
            {
                dashTime -= Time.deltaTime;

                if(direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    
                }
                if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    
                }
            }
        }
        ////////////////////D A S H/ /////////////////////////

	}

	public void Knockback()
	{
		knockbackCounter = knockbackLength;
		invincibilityCounter = invincibilityLength;
		theLevelManager.invincible = true;
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "KillPlane")
		{
			//gameObject.SetActive(false);

			//transform.position = respawnPosition;

			theLevelManager.Respawn();
		}

		if(other.tag == "Checkpoint")
		{
			respawnPosition = other.transform.position;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "MovingPlatform")
		{
			transform.parent = other.transform;
			onPlatform = true;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag == "MovingPlatform")
		{
			transform.parent = null;
			onPlatform = false;
		}
	}
}
