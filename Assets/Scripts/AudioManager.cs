using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    //public AudioClip gemClip, coinClip, cherryClip, healthClip; //Referenser för de olika ljuden
    public AudioClip jumpSound;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip); //Spela upp ljudklippet
    }

    public void Jump()
    {
        audioSource.PlayOneShot(jumpSound); //Spela upp hoppljudet
    }
}
