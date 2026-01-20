using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public CheckpointScript[] checkpoints; //Array innehållande alla checkpointscript
    private Vector3 spawnPosition; //Checkpointens position som spelaren ska spawna vid
    private LevelManager levelManager;                              

    void Start()
    {
        //Sök reda på checkpoints utan sortering
        checkpoints = FindObjectsByType<CheckpointScript>(FindObjectsSortMode.None);
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    
    public void DeactivateCheckpoints(Vector3 spawnPos) //Funktion som sätter alla checkpoints till off
    {
        foreach(CheckpointScript checkpoint in checkpoints)  //Loopa igenom arrayen
        {
            checkpoint.ResetCheckpoint(); //Kalla på reset-funktionen
        }

        spawnPosition = spawnPos; //Byt spawnposition till den aktiva checkpointens position
        levelManager.ChangeSpawnpoint(spawnPos); //Skicka med CP position som ny spawnpoint
    }
}
