using UnityEngine;
using UnityEngine.UI;

public class UIhandler : MonoBehaviour
{
    public PlayerHealth playerHealth; //Referensfält för healthscriptet
    public Image healthBar; //Referens till healthgrafiken
    public Text pointsText; //Referens till poängtexten
    private int pickupPoints; //Spelarens poäng
    public int coinValue = 5; //Objektens poängvärde
    public int gemValue = 10;
    public int cherryValue = 25;

    private void Start()
    {
        pickupPoints = 0; //Resetta poängen
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,(float)playerHealth.currHealth / 100, 0.01f); //Visa health.Konvertera int till float
        pointsText.text = pickupPoints.ToString(); //Koppla pointsvariabeln till texten
    }

    public void PickupCoin()
    {
        pickupPoints += coinValue; //Lägg till objektets värde till totalen
    }

    public void PickupGem()
    {
        pickupPoints += gemValue; //Lägg till objektets värde till totalen
    }

    public void PickupCherry()
    {
        pickupPoints += cherryValue; //Lägg till objektets värde till totalen
    }
}
