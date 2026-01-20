using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; //Spelarens position
    public float smoothTime = 0.25f; //Den tid det tar innan kameran nått sin position
    private Vector3 camVelocity; //Variabel som lagrar resultatet av beräkningen av kamerans pos
    public float minHeight, maxHeight; //Variabler som begränsar kamerans rörelse i Y-led.

    public Transform farBackground, middleBackground , nearBackground; //Parentobjekt för parallax
    private Vector2 lastCamPos; //Lagrar kamerans pos under föregående frame
    public float parallaxYmiddle = 1f;
    public float parallaxYnear = 1f;
    public float middlegroundSpeed = 0.5f; //Lagrens olika parallax-hastigheter
    public float nearGroundSpeed = 0.2f;

    void Start()
    {
        
    }

 
    void LateUpdate()
    {
        //Låt kameran följa spelaren i x och y-led och lagra positionen i camPos
        Vector3 camPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        float camClampY = Mathf.Clamp(camPos.y, minHeight, maxHeight); //Begränsa kameran i Y-led
        Vector3 clampedCamPos = new Vector3(camPos.x,camClampY, camPos.z); //Vektor med begränsat Y-värde

        //Smootha kameran. SmoothTime ställer hur lång tid det tar för kameran att nå sin slutpos
        transform.position = Vector3.SmoothDamp(transform.position, clampedCamPos, ref camVelocity, smoothTime);

        //Parallax
        farBackground.position = new Vector3(transform.position.x, 0f, 0f); //Lås bakgrunden till kameran
        middleBackground.position = new Vector3(transform.position.x * middlegroundSpeed, transform.position.y - lastCamPos.y * parallaxYmiddle, 0f); //Mellangrund har ett annat parallaxvärde
        nearBackground.position = new Vector3(transform.position.x * nearGroundSpeed, transform.position.y - lastCamPos.y * parallaxYnear, 0f); //Närgrund har ett annat parallaxvärde
        lastCamPos = transform.position; //Uppdatera lastCamPos
    }
}
