using System.Net.Sockets;
using UnityEngine;

public class LightningMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float lightningSpeed = 1000;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(lightningSpeed, 0);
    }

    void Update()
    {
        
    }
}
