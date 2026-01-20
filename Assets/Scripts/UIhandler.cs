using UnityEngine;
using UnityEngine.UI;

public class UIhandler : MonoBehaviour
{
    public PlayerHealth playerHealth; //Referensfält för healthscriptet
    public Image healthBar; //Referens till healthgrafiken

    private void Start()
    {

    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,(float)playerHealth.currHealth / 100, 0.01f); //Visa health.Konvertera int till float
    }
}
