using UnityEngine;

public class LightningScript : MonoBehaviour
{
    public GameObject lightningPrefab;
    public float time;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z) && time > 4)
        {
            Instantiate(lightningPrefab, transform.position + new Vector3(1,0,0), Quaternion.identity); //Instatiate(vad, vart, vilken position
            time = 0;
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
