using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public bool isActive; //Boolean som blir sann när styrobjektet ska aktiveras
    public SpriteRenderer spriteRenderer; //Referens till spriterenderer
    public Sprite on; //Referens till on-spriten

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") //Kolla om spelaren interagerar med switchen
        {
            isActive = true; //Sätt boolen till true
            spriteRenderer.sprite = on; //Byt sprite när switchen aktiveras
        }
    }
}
