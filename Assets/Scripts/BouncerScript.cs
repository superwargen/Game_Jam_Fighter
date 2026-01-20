using UnityEngine;

public class BouncerScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    public float jumpForce = 10f; //Kraften som slungar spelaren uppåt

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animator.SetTrigger("jumpTrigger"); //Växla animationsstate
            
            Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>(); //Sök upp spelarens rigidbody
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpForce); //Slunga spelaren uppåt
            audioSource.Play();
        }
    }
}
