using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float moveSpeed = 7f; //Spelarens hastighet
    public float jumpForce = 1f; //Hoppkraft
    public bool isGrounded; //Bool som är sann om spelaren står på marken
    public Transform groundPos; //Den position där groundchecken utförs från
    public LayerMask groundLayer; //Det lager groundchecken tittar i efter objekt
    private Animator animator; //Referens till animatorn
    private SpriteRenderer spriteRenderer;
    public float knockbackTime = 0.2f; //Den tid knockback är aktiv
    private float knockbackTimer; //Timervariabel
    public float knockbackForce = 8f; //Den kraft som spelaren kastas med hjälp av
    private bool knockback; //Bool som är sann när knockback är aktivt
    private AudioManager audioManager;
    //private float inputValue;
    private bool isRunning = false;
    public bool isPunching = false;

    public bool isPlayerOne = false;
    public Transform punchRight, punchLeft; //Position för spelarens slag
    public float punchTime = 0.2f; //Den tid knockback är aktiv
    private float punchTimer; //Timervariabel
    private PlayerHealth playerHealth;

    //Ladder
    public float climbSpeed = 6f; //Klättringshastighet
    public bool canClimb; //Boolean som blir sann när spelaren står vid en stege


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = FindFirstObjectByType<AudioManager>();
    }

 


    void LateUpdate()
    {
        if (!knockback) //Ta bort spelarinput om immune är aktivt
        {
            //Ta in input

            //rigidbody.linearVelocity = new Vector2(moveSpeed * Input.GetAxis("wasd"), rigidbody.linearVelocity.y); 
            if (isPlayerOne)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    //rigidbody.linearVelocity = new Vector2(moveSpeed, rigidbody.linearVelocity.y);
                    //inputValue = 1;
                    transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
                    spriteRenderer.flipX = false; //Byt inte riktning på spriten
                    isRunning = true;
                    animator.SetBool("isRunning", isRunning);

                }

                else if (Input.GetKey(KeyCode.A))
                {
                    //rigidbody.linearVelocity = new Vector2(-moveSpeed, rigidbody.linearVelocity.y);
                    //inputValue = -1;
                    transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
                    spriteRenderer.flipX = true; //Byt riktning på spriten
                    isRunning = true;
                    animator.SetBool("isRunning", isRunning);

                }


                else
                {
                    isRunning = false;
                    animator.SetBool("isRunning", isRunning);

                }

                if (Input.GetKeyDown(KeyCode.W) && isGrounded) //Hoppfunktion som tar hänsyn till om spelaren står på marken
                {
                    audioManager.Jump(); //Spela upp hoppljudet
                    rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Lägg på en kraft uppåt
                }

                if (Input.GetKeyDown(KeyCode.Q) && punchTimer <= 0)
                {
                    Punch();
                }

            }

            if (!isPlayerOne)
            {
                if (Input.GetKey(KeyCode.L))
                {
                    //rigidbody.linearVelocity = new Vector2(moveSpeed, rigidbody.linearVelocity.y);
                    //inputValue = 1;
                    transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
                    spriteRenderer.flipX = false; //Byt inte riktning på spriten
                    isRunning = true;
                    animator.SetBool("isRunning", isRunning);
                }

                else if (Input.GetKey(KeyCode.J))
                {
                    //rigidbody.linearVelocity = new Vector2(-moveSpeed, rigidbody.linearVelocity.y);
                    //inputValue = -1;
                    transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
                    spriteRenderer.flipX = true; //Byt riktning på spriten
                    isRunning = true;
                    animator.SetBool("isRunning", isRunning);
                }

                else
                {
                    isRunning = false;
                    animator.SetBool("isRunning", isRunning);

                }

                if (Input.GetKeyDown(KeyCode.I) && isGrounded) //Hoppfunktion som tar hänsyn till om spelaren står på marken
                {
                    audioManager.Jump(); //Spela upp hoppljudet
                    rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Lägg på en kraft uppåt
                }

                if (Input.GetKeyDown(KeyCode.O) && punchTimer <= 0)
                {
                    Punch();
                }
            }

            if (canClimb)
            {
                //Slå på vertikal input för klättring
                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocityX, climbSpeed * Input.GetAxis("Vertical"));

                float verticalMovement = Mathf.Abs(Input.GetAxis("Vertical")); //Lagra vertikal input.Ta bort ev. negativa siffror

                if (verticalMovement > 0) //Kolla om spelaren trycker på pil upp/ned
                {
                    animator.SetBool("canClimb", canClimb); //Växla till climb-animation
                    animator.SetFloat("climbSpeed", verticalMovement); //Koppla vertmove till animationens hastighet 

                }
            }
            else  //Slå av flip-funktion medan spelaren klättrar
            {
                animator.SetBool("canClimb", canClimb); //Växla till idle-animation

                if (rigidbody.linearVelocityX < 0) //Kolla om spelaren rör sig åt vänster
                {
                    spriteRenderer.flipX = true; //Byt riktning på spriten
                }
                else if (rigidbody.linearVelocityX > 0) //Kolla om spelaren rör sig åt höger
                {
                    spriteRenderer.flipX = false;  //Byt inte riktning på spriten
                }
            }

                //Utför groundcheck med hjälp av en overlapcircle placerad vid spelarens fötter
                isGrounded = Physics2D.OverlapCircle(groundPos.position, 0.2f, groundLayer);

            animator.SetBool("isGrounded", isGrounded);
            animator.SetFloat("playerSpeed", Mathf.Abs(rigidbody.linearVelocityX)); //Koppla animatorns playerSpeedparameter till spelarens hastighet
        }

        KnockbackTimer();
        PunchTimer();
    }

    public void Punch()
    {
        punchTimer = punchTime; //Starta timern
        isPunching = true;
        animator.SetBool("isPunching", isPunching);
        if (spriteRenderer.flipX) //Kolla om spriten är flippad
        {
            punchLeft.gameObject.SetActive(true);

        }
        else
        {
            punchRight.gameObject.SetActive(true);

        }
    }

    void PunchTimer()
    {
        if (punchTimer > 0) //Starta timern om kbt har annat värde än 0
        {
            punchTimer -= Time.deltaTime; //Baklängestimer
        }
        else if (punchTimer <= 0) //Timern har räknat ned
        {
            isPunching = false; //Tillåt slag
            animator.SetBool("isPunching", isPunching);

            if (spriteRenderer.flipX) //Kolla om spriten är flippad
            {
                punchLeft.gameObject.SetActive(false);
            }
            else
            {
                punchRight.gameObject.SetActive(false);
            }

        }
    }

    public void Knockback()
    {
        knockbackTimer = knockbackTime; //Starta timern
        knockback = true;

        if(spriteRenderer.flipX) //Kolla om spriten är flippad
        {
            //Lägg på en kraft åt höger
            rigidbody.AddForce(transform.right * knockbackForce, ForceMode2D.Impulse);
        }
        else
        {
            //Lägg på en kraft åt vänster
            rigidbody.AddForce(-transform.right * knockbackForce, ForceMode2D.Impulse);
        }
    }

    void KnockbackTimer()
    {
        if(knockbackTimer > 0) //Starta timern om kbt har annat värde än 0
        {
            knockbackTimer -= Time.deltaTime; //Baklängestimer
        }
        else if(knockbackTimer <= 0) //Timern har räknat ned
        {
            knockback = false; //Tillåt inte knockback
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ladder") //Kolla om det är stegen spelaren kolliderar med
        {
            canClimb = true; //Slå på klätterfunktionen
            rigidbody.bodyType = RigidbodyType2D.Kinematic; //Sätt RB till kinematic
        }

        if(collision.tag == "RightPunch")
        {
            //transform.position = new Vector3(transform.position.x+1, transform.position.y, transform.position.z);
            Debug.Log("Test1");

            transform.GetComponent<PlayerHealth>().GiveDamage(2);
        }

        if (collision.tag == "LeftPunch")
        {
            //transform.position = new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
            Debug.Log("Test2");
            transform.GetComponent<PlayerHealth>().GiveDamage(2);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder") //Kolla om det är stegen spelaren kolliderar med
        {
            canClimb = false; //Slå av klätterfunktionen
            rigidbody.bodyType = RigidbodyType2D.Dynamic; //Resetta RB
        }
    }

}
