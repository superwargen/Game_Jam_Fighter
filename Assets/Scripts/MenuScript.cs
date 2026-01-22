using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class MenuScript : MonoBehaviour
{
    private string sceneName;
    

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void Play()
    {
        SceneManager.LoadScene(1); //Byt till level 1
    }

    public void Credits()
    {
        SceneManager.LoadScene(3); 

        //todo: lägg till scen för Credits och använd SceneManager för att byta till
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
