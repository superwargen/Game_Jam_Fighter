using UnityEngine;

public class KillCollider : MonoBehaviour
{
    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().currHealth = 0; //Sätt spelarens healthvärde till 0
            levelManager.Respawn();
        }
    }
}
