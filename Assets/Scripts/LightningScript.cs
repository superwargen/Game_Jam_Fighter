using UnityEngine;

public class LightningScript : MonoBehaviour
{
    public GameObject lightningPrefab;
    public float timeOne = 3;
    public float timeTwo = 3;
    public bool isHammerOne;

    void Start()
    {
        
    }

    void Update()
    {
        if (isHammerOne)
        {
            timeOne += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Z) && timeOne > 3)
            {
                Instantiate(lightningPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity); //Instatiate(vad, vart, vilken position
                timeOne = 0;
            }
        }
        if (!isHammerOne)
        {
            timeTwo += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.M) && timeTwo > 3)
            {
                Instantiate(lightningPrefab, transform.position + new Vector3(-1, 0, 0), Quaternion.Euler(0,180,0)); //Instatiate(vad, vart, vilken position

                timeTwo = 0;
            }
        }


    }






    //else
    //{
    //    //Debug.Log("Game Over!");
    //    //Lägg in kod för byte
    //    Destroy(gameObject); //Förstör paddeln så att den inte följer med i game over scenen
    //    gameManagerScript.GameOver(); //Spelaren har förlorat. Spelet är slut
    //}

}
