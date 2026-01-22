using UnityEngine;

public class LightningScript : MonoBehaviour
{
    public GameObject lightningPrefab;
<<<<<<< HEAD
    public float time = 3;
=======
>>>>>>> parent of de50bb7 (Grejer)

    void Start()
    {
        
    }

    void Update()
    {
<<<<<<< HEAD
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z) && time > 3)
=======
        if (Input.GetKeyDown(KeyCode.Z))
>>>>>>> parent of de50bb7 (Grejer)
        {
            Instantiate(lightningPrefab, transform.position + new Vector3(1,0,0), Quaternion.identity); //Instatiate(vad, vart, vilken position
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
