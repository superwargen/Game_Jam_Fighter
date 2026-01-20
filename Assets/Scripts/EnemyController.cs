using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Transform leftTarget, rightTarget; //Patrullmål
    private Rigidbody2D rigidbody;
    public bool movingRight; //Bool som avgör rörelseriktning
    private SpriteRenderer sprite;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if(movingRight) //Rör sig NPC åt höger?
        {
            //Flytta NPC åt höger med en hastighet motsvarande moveSpeed
            rigidbody.linearVelocity = new Vector2(moveSpeed,rigidbody.linearVelocityY);
            //Kolla om NPC nått det högra målet
            if(transform.position.x > rightTarget.transform.position.x)
            {
                movingRight = false; //Växla riktning
                sprite.flipX = false; //Flippa spriten
            }
        }
        else
        {
            //Flytta NPC åt vänster med en hastighet motsvarande moveSpeed
            rigidbody.linearVelocity = new Vector2(-moveSpeed, rigidbody.linearVelocityY);
            //Kolla om NPC nått det vänstra målet
            if (transform.position.x < leftTarget.transform.position.x)
            {
                movingRight = true; //Växla riktning
                sprite.flipX = true; //Flippa spriten
            }
        }

    }
}
