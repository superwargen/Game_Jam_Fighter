using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Vector3 spawnpoint; //Punkt där spelaren återuppstår vid död
    public GameObject player; //Referens till spelaren
    public float respawnTime = 4f; //Den tid det tar innan spelaren återuppstår

    public void Respawn()
    {
        StartCoroutine(RespawnTimer());
    }

    private IEnumerator RespawnTimer() //Timer som fördröjer återuppståndelsen
    {
        player.SetActive(false); //Inaktivera spelaren
        yield return new WaitForSeconds(respawnTime); //Vänta x-antal sekunder
        player.GetComponent<PlayerHealth>().Start(); //Kör start för att resetta healthvärdet
        player.transform.position = spawnpoint; //Flytta spelaren till spawnpoint
        player.SetActive(true); //Reaktivera spelaren
    }

    public void ChangeSpawnpoint(Vector3 spawnPos) //Funktion som sätter spawnpoint till aktuell checkpoint
    {
        spawnpoint = spawnPos;
    }
}
