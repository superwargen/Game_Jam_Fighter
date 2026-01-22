using UnityEngine;

public class LjudManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip fightingMusic;

    void Start()
    {
        audioSource.PlayOneShot(fightingMusic);
    }

    void Update()
    {
        
    }
}
