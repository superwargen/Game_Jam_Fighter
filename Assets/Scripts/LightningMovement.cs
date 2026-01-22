using System.Net.Sockets;
using UnityEngine;

public class LightningMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float lightningSpeed = 10;
    public bool isLightningOne;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (isLightningOne)
        {
            rb.linearVelocity = new Vector2(lightningSpeed, 0);

        }
        if (!isLightningOne)
        {
            rb.linearVelocity = new Vector2(-lightningSpeed, 0);

        }
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //audioSource.PlayOneShot(deathSound); //Spelar upp deathsound
            //spriteRenderer.enabled = false;
            //collider.enabled = false;
            Destroy(gameObject);
        }
    }
}
