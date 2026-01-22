using UnityEngine;
using UnityEngine.UI;

public class VictoryScript : MonoBehaviour
{
    public PlayerHealth playerHealth1, playerHealth2; //Referensfält för healthscriptet
    public Transform Victory1, Victory2; //Referens till healthgrafiken

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth1.currHealth <= 0) { Victory2.gameObject.SetActive(true); }
        if (playerHealth2.currHealth <= 0) { Victory1.gameObject.SetActive(true); }
    }
}
