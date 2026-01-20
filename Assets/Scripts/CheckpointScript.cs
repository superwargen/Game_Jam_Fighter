using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public Sprite on, off; //Referenser för sprites
    private SpriteRenderer spriteRenderer;
    private CheckpointManager checkpointManager;
    private BoxCollider2D collider; //Fält för collidern
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        checkpointManager = FindFirstObjectByType<CheckpointManager>();
        collider = GetComponent<BoxCollider2D>();
    }


    public void ResetCheckpoint()
    {
        spriteRenderer.sprite = off; //Sätt spriten till off-sprite
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Kalla på deactivate-funktionen och skicka samtidigt med checkpointens placering som ny spawnpoint
            checkpointManager.DeactivateCheckpoints(transform.position); 
            spriteRenderer.sprite = on; //Byt sprite till on
            collider.enabled = false; //Slå av collidern så att vi inte kan sätta CP aktivt igen
        }
    }
}
