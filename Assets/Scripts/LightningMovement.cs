using System.Net.Sockets;
using UnityEngine;

public class LightningMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float lightningSpeed = 10;
    public bool isLightningOne;
    public SpriteRenderer playerSprite;
    public int lightningDamage = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (isLightningOne)
        {
            if (playerSprite.flipX) 
            {
                rb.linearVelocity = new Vector2(-lightningSpeed, 0);
            }

            else 
            {
                rb.linearVelocity = new Vector2(lightningSpeed, 0);
            }
            

        }
        if (!isLightningOne)
        {
            if (playerSprite.flipX)
            {
                rb.linearVelocity = new Vector2(-lightningSpeed, 0);
            }

            else
            {
                rb.linearVelocity = new Vector2(lightningSpeed, 0);
            }

        }
    }

    void Update()
    {
        
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Player" && gameObject.tag == "Ligthning2")
    //    {
    //        //audioSource.PlayOneShot(deathSound); //Spelar upp deathsound
    //        //spriteRenderer.enabled = false;
    //        //collider.enabled = false;

    //        Destroy(gameObject);
    //    }

    //    if (other.gameObject.tag == "Player2" && gameObject.tag == "Ligthning1")
    //    {
    //        //audioSource.PlayOneShot(deathSound); //Spelar upp deathsound
    //        //spriteRenderer.enabled = false;
    //        //collider.enabled = false;

    //        Destroy(gameObject);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && gameObject.tag == "Test2") //Kolla om vi kolliderar med spelaren
        {
            //Sök upp healthscriptet och skicka in skadan som en parameter
            collision.transform.GetComponent<PlayerHealth>().GiveDamage(lightningDamage);
            Destroy(gameObject);
        }

        if (collision.transform.tag == "Player2" && gameObject.tag == "Test1") //Kolla om vi kolliderar med spelaren
        {
            //Sök upp healthscriptet och skicka in skadan som en parameter
            collision.transform.GetComponent<PlayerHealth>().GiveDamage(lightningDamage);
            Destroy(gameObject);
        }
    }



    //public void LightningDestruction(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Player" && gameObject.tag == "Ligthning2")
    //    {
    //        //audioSource.PlayOneShot(deathSound); //Spelar upp deathsound
    //        //spriteRenderer.enabled = false;
    //        //collider.enabled = false;

    //        Destroy(gameObject);
    //    }

    //    if (other.gameObject.tag == "Player2" && gameObject.tag == "Ligthning1")
    //    {
    //        //audioSource.PlayOneShot(deathSound); //Spelar upp deathsound
    //        //spriteRenderer.enabled = false;
    //        //collider.enabled = false;

    //        Destroy(gameObject);
    //    }
    //}
}
