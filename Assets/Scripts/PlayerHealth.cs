using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currHealth; //Nuvarande healthvärde
    public int maxHealth = 100; //Spelarens maximala healthvärde
    public float immuneTime = 1f; //Den tid spelaren är immun mot skada
    private float immuneCounter; //Immunesystemets timervariabel
    private SpriteRenderer spriteRenderer;
    private Color immuneColor; //Färg som används när spelaren är immun
    private bool immune; //Bool som är sann när spelaren är immun
    private PlayerScript playerScript; //Referens till playerscriptet
    public LevelManager levelManager; //Referens till LevelManager-scriptet
    public int healthValue = 10; //Health som adderas när man plockar upp ett healthpack

    public void Start()
    {
        currHealth = maxHealth; //Resetta health
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerScript = GetComponent<PlayerScript>();
    }

    
    void Update()
    {
        //Färg med växlande alpha
        immuneColor = new Color(1, 1, 1, Mathf.PingPong(Time.time * 5f, 1f));

        if(immune) //Spelaren är immun
        {
            spriteRenderer.color = immuneColor; //Växla till immunecolor
        }

        if(immuneCounter > 0) //Starta timern om immunecountervärdet är högre än 0
        {
            immuneCounter -= Time.deltaTime; //Baklängestimer
            immune = true; 
        }
        else //Spelaren är inte längre immun
        {
            immune = false; 
            spriteRenderer.color = new Color(1, 1, 1, 1); //Gör spriten ogenomskinlig
        }
    }

    public void GiveDamage(int damageAmount)
    {
        if (immuneCounter <= 0) //Ta skada enbart när vi inte är immuna
        {
            //playerScript.Knockback(); //Kalla på knockback-funktionen
            currHealth -= damageAmount; //Dra av skadevärde från health

            if (currHealth <= 0) //Lever spelaren?
            {
                levelManager.Respawn(); 
            }
            else
            {
                //immuneCounter = immuneTime; //Sätt timern till immuntiden
            } 
        }
    }

    public void GiveHealth()
    {
        if(currHealth < maxHealth) //Kolla om spelaren får ta upp ett healthpack
        {
            currHealth += healthValue; //Lägg till health
        }
        if (currHealth > maxHealth) //Kolla om maxhealth överskrids
        {
            currHealth = maxHealth; //Sätt i så fall health till maxhealth
        }
    }
}
