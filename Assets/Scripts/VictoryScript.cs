using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScript : MonoBehaviour
{
    public PlayerHealth playerHealth1, playerHealth2; //Referensfält för healthscriptet
    public Transform Victory1, Victory2; //Referens till healthgrafiken
    public float timmerStart = 5;
    private float countDown;

    void Start()
    {
        countDown = timmerStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth1.currHealth <= 0) 
        { 
            Victory2.gameObject.SetActive(true); 

            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else 
            {
                SceneManager.LoadScene(0);
            }

        }

        if (playerHealth2.currHealth <= 0) 
        { 
            Victory1.gameObject.SetActive(true);

            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(0);
            }

        }
    }
}
