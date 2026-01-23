using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class LightningScript : MonoBehaviour
{
    public GameObject lightningPrefab;
    public float timeOne = 3;
    public float timeTwo = 3;
    public bool isHammerOne;
    public AudioSource audioSource;
    public AudioClip shockSound;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
        if (isHammerOne)
        {
            timeOne += Time.deltaTime;

            //if (spriteRenderer.flipX) 
            //{
            //    transform.position = new Vector3(-0.629999995f, -0.279999971f, 0f);
            //    transform.rotation = new(0, 0f, 0f, 34.6640015f);
            //}

            //else 
            //{
            //    transform.position = new Vector3(0.49000001f, -0.279999971f, 0f);
            //    transform.rotation = new(0, 0f, 0f, 325.335999f);
            //}

            if (Input.GetKeyDown(KeyCode.Z) && timeOne > 3)
            {
                if (spriteRenderer.flipX)
                {
                        Instantiate(lightningPrefab, transform.position + new Vector3(-1, 0, 0), Quaternion.Euler(0, 180, 0)); //Instatiate(vad, vart, vilken position
                        audioSource.PlayOneShot(shockSound);
                        timeTwo = 0;
                }

                else
                {
                    Instantiate(lightningPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity); //Instatiate(vad, vart, vilken position
                    audioSource.PlayOneShot(shockSound);
                    timeOne = 0;
                } 
            }

        }
        if (!isHammerOne)
        {
            timeTwo += Time.deltaTime;

            //if (spriteRenderer.flipX)
            //{
            //    transform.position = new Vector3(-0.629999995f, -0.279999971f, 0f);
            //    transform.rotation = new(0, 0f, 0f, 34.6640015f);
            //}

            //else
            //{
            //    transform.position = new Vector3(0.49000001f, -0.279999971f, 0f);
            //    transform.rotation = new(0, 0f, 0f, 325.335999f);
            //}

            if (Input.GetKeyDown(KeyCode.M) && timeTwo > 3)
            {
                if (spriteRenderer.flipX)
                {
                    Instantiate(lightningPrefab, transform.position + new Vector3(-1, 0, 0), Quaternion.Euler(0, 180, 0)); //Instatiate(vad, vart, vilken position
                    audioSource.PlayOneShot(shockSound);
                    timeTwo = 0;
                }

                else
                {
                    Instantiate(lightningPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity); //Instatiate(vad, vart, vilken position
                    audioSource.PlayOneShot(shockSound);
                    timeTwo = 0;
                }
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
