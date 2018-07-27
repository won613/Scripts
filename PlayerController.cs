using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private float activeMoveSpeed;
    //체력
    public int hp;
    private float discountHP;
    public int staticHp;
    public Image hpGage;
    //산소
    public float oxygenpoint;
    public Image oxygenGage;
    //스테미너
    public float stamina;
    public Image staminaGage;
    private bool staminaCheck;
    public float refillStaminatime;
    private float startrefillStamina;
    private bool refillstaminaCheck;
    
    
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
    public GameObject shotgun;
    public GameObject grenade;
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
    private bool dashCheck;

    ///////////////////////// </ D A S H >

    void Awake()
    {
        playerGraphics = transform.Find("Graphics");
        if (playerGraphics == null)
        {
            Debug.LogError("There is no 'Graphics' object as a child of the player");
        }
    }

    // Use this for initialization
    void Start()
    {
        //UI에 띄우기 위한 초기 hp값 대입
        staticHp = hp;
        discountHP = (float)hp;

		myRigidbody = GetComponent<Rigidbody2D>();
        //myAnim = GetComponent<Animator>();

        respawnPosition = transform.position;

        theLevelManager = FindObjectOfType<LevelManager>();

        activeMoveSpeed = moveSpeed;

        canMove = true;

        takeUpstair = false;
        takeDownstair = false;

        direction = 0;
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        dashCheck = false;
        staminaCheck = false;
        refillstaminaCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp==0)
        {
            Destroy(gameObject);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (knockbackCounter <= 0 && canMove)
        {
		
            if (onPlatform)
            {
                activeMoveSpeed = moveSpeed * onPlatformSpeedModifier;
            }
            else
            {
                activeMoveSpeed = moveSpeed;
            }

            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f);
                playerGraphics.localScale = new Vector3(1f, 1f, 1f);
                walkDirection = 2;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                myRigidbody.velocity = new Vector3(-activeMoveSpeed, myRigidbody.velocity.y, 0f);
                playerGraphics.localScale = new Vector3(-1f, 1f, 1f);
                walkDirection = 1;
            }
            else
            {
                myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
                jumpSound.Play();
            }
        }

        if (whatGun == 0)
        {
            pistol.SetActive(true);
        }

        if (whatGun == 1)
        {
            mp5.SetActive(true);
            pistol.SetActive(false);
        }

        if (whatGun == 2)
        {
            shotgun.SetActive(true);
            pistol.SetActive(false);
        }

        if (whatGun == 3)
        {
            grenade.SetActive(true);
            pistol.SetActive(false);
        }

        //산소 게이지
        oxygenGage.fillAmount = oxygenpoint / 100;
        oxygenpoint -= Time.deltaTime * 2f;

        hpGage.fillAmount = discountHP / 100;

        if (oxygenpoint < 0)
        {
            oxygenpoint = 0;
        }

        if (oxygenpoint == 0)
        {
            discountHP -= Time.deltaTime * 2f;
            hp = (int)discountHP;
            if (hp < 0)
            {
                hp = 0;
            }
        }

        if (takeUpstair == true)
        {
            transform.position = new Vector3(downstairPosition.transform.position.x, downstairPosition.transform.position.y, 0);
            takeUpstair = false;
        }

        if (takeDownstair == true)
        {
            transform.position = new Vector3(upstairPosition.transform.position.x, upstairPosition.transform.position.y, 0);
            takeDownstair = false;
        }

        if (knockbackCounter > 0)
        {
            knockbackCounter -= Time.deltaTime;

            if (transform.localScale.x > 0)
            {
                myRigidbody.velocity = new Vector3(-knockbackForce, knockbackForce, 0f);
            }
            else
            {
                myRigidbody.velocity = new Vector3(knockbackForce, knockbackForce, 0f);
            }
        }

        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
        }

        if (invincibilityCounter <= 0)
        {
            theLevelManager.invincible = false;
        }

        //myAnim.SetFloat("Speed", Mathf.Abs( myRigidbody.velocity.x));
        //myAnim.SetBool("Grounded", isGrounded);

        if (myRigidbody.velocity.y < 0)
        {
            stompBox.SetActive(true);
        }
        else
        {
            stompBox.SetActive(false);
        }

        //구르기
        //////// D A S H /////////////////////////////////
        staminaGage.fillAmount = stamina / 5;
        if (stamina > 0)
        {
            if (direction == 0)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    dashCheck = true;
                    staminaCheck = true;
                    if (dashCheck)
                    {
                        if (walkDirection == 1)
                        {
                            direction = 1;
                        }
                        else if (walkDirection == 2)
                        {
                            direction = 2;
                        }
                    }

                }

                if (Input.GetMouseButtonUp(1))
                {
                    dashCheck = false;
                }

            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;

                    if (staminaCheck && direction == 1)
                    {

                        rb.velocity = Vector2.left * dashSpeed;
                        stamina--;
                        if (stamina < 0)
                        {
                            stamina = 0f;
                        }
                        staminaCheck = false;

                    }

                    else if (staminaCheck && direction == 2)
                    {
                        rb.velocity = Vector2.right * dashSpeed;
                        stamina--;
                        if (stamina < 0)
                        {
                            stamina = 0f;
                        }
                        staminaCheck = false;
                    }
                }
            }
        }

        if (stamina < 5)
        {
            refillstaminaCheck = true;
            startrefillStamina += Time.deltaTime;
            if (refillStaminatime <= startrefillStamina&& refillstaminaCheck)
            {
                refillstaminaCheck = false;
                startrefillStamina = 0;
                stamina++;
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
        if (other.tag == "KillPlane")
        {
            //gameObject.SetActive(false);

            //transform.position = respawnPosition;

            theLevelManager.Respawn();
        }

        if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
            onPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
            onPlatform = false;
        }
    }
}
