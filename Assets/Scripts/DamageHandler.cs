using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int damageValue = 2;
    public GameObject deathEffect; //Referensfält för explosionsprefaben
    public GameObject[] pickUp; //Objekt som instansieras när grodan dör
    public Transform pickupSpawn; //Den punkt där pickup-objektet spawnas vid
    public int randomizer; //Heltal som slumpar fram vilket pickup-objekt som ska skapas

    private void Start()
    {
        randomizer = Random.Range(0, pickUp.Length + 1); //Slumpa ett tal mellan 0 o antalet element i arrayen
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player") //Kolla om vi kolliderar med spelaren
        {
            //Sök upp healthscriptet och skicka in skadan som en parameter
            collision.transform.GetComponent<PlayerHealth>().GiveDamage(damageValue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Instansiera ett pickup-objekt
            Instantiate(pickUp[randomizer], pickupSpawn.transform.position, Quaternion.identity);
            //Instansiera en explosion där grodan står
            GameObject fx = Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Förstör explosionen
            Destroy(fx, 0.4f);
            //Förstör grodans parentobjekt
            Destroy(transform.parent.gameObject);
        }
    }
}
