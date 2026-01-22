using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class MenuScript : MonoBehaviour
{
    private string sceneName;
    public AudioSource audioSource;
    public AudioClip menuMusic;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(menuMusic);

    }

    public void Play()
    {
        SceneManager.LoadScene(1); //Byt till level 1
    }

    public void Credits()
    {
        SceneManager.LoadScene(2); 

        //todo: lägg till scen för Credits och använd SceneManager för att byta till
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
