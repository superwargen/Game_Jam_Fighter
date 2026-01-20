using UnityEngine;

public class SpriteTilingScript : MonoBehaviour
{
    private float spriteWidth; //Hur lång bakgrundsspriten är
    private Sprite sprite; //Referens till texturen
    private Transform camera; //Referens till kameran

    void Start()
    { 
        camera = Camera.main.transform;
        sprite = GetComponent<SpriteRenderer>().sprite; //Sök upp spritetexturen
        spriteWidth = sprite.texture.width / sprite.pixelsPerUnit; //Räkna ut hur bred spriten är
    }

   
    void Update()
    {
        //Kameran närmar sig spritens kant. Abs möjliggör rörelse åt vänster
        if(Mathf.Abs(camera.transform.position.x - transform.position.x) >= spriteWidth)
        {
            //Lagra återstiden av subtraktionen av kamerans och bakgrundens posX.
            float offsetPosX = (camera.position.x - transform.position.x) % spriteWidth;
            //Flytta spritens mittpunkt till den gamla skarven så ingen glipa syns
            transform.position = new Vector3(camera.position.x + offsetPosX,
                transform.position.y, transform.position.z);
        }
    }
}
