using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public enum PickupType { Gem, Coin, Cherry, Health}
    public PickupType pickupType; //Variabel som lagrar valet av objekttyp
    private UIhandler uIhandler; //Referens till UIhandler-scriptet
    private PlayerHealth playerHealth;
    private AudioManager audioManager;
    public AudioClip audioClip; //Referens till ljudet som ska skickas med som parameter

    private void Start()
    {
        uIhandler = FindFirstObjectByType<UIhandler>(); //Sök upp UiHandler
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            switch (pickupType)
            {
                case PickupType.Gem:
                    uIhandler.PickupGem();
                    audioManager.PlaySound(audioClip); //Spela upp ljudklippet
                    Destroy(gameObject);
                    break;
                case PickupType.Coin:
                    uIhandler.PickupCoin();
                    audioManager.PlaySound(audioClip); //Spela upp ljudklippet
                    Destroy(gameObject);
                    break;
                case PickupType.Cherry:
                    uIhandler.PickupCherry();
                    audioManager.PlaySound(audioClip); //Spela upp ljudklippet
                    Destroy(gameObject);
                    break;
                case PickupType.Health:
                    Health();
                    break;
            }
        }
    }

    void Health()
    {
        if (playerHealth.currHealth < playerHealth.maxHealth)
        {
            audioManager.PlaySound(audioClip); //Spela upp ljudklippet
            Destroy(gameObject); 
        }

        playerHealth.GiveHealth();
    }
}
