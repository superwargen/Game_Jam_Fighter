using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    private int waypointIndex;
    public Transform player; //Referens till spelaren
    public SwitchScript switchScript; //Referens till switchscriptet
    
    
    void Update()
    {
        //Rör plattformen mot aktuell waypoint
        if (switchScript.isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            waypoints[waypointIndex].position, moveSpeed * Time.deltaTime); 
        }

        //Mät avståndet mellan plattformen och aktuell waypoint (mål)
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) <= 0.1f)
        {
            waypointIndex++;
        }

        if(waypointIndex >= waypoints.Length) //Kolla om plattformen nått den sista waypointen
        {
            waypointIndex = 0; //Loopa i så fall
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") //Kolla om det är spelaren som vill åka med
        {
            player.transform.parent = this.transform;  //Parenta spelaren till plattformen
        }
    }

    private void OnCollisionExit2D(Collision2D collision) //Funktion för att "avparenta" spelaren
    {
        if(collision.gameObject.tag == "Player")
        {
            player.transform.parent = null; //Sätt spelarens parent till noll och intet
        }
    }
}
