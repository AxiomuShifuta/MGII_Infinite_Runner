using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    private float length, startPos;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        //Agregado deltaTime para dar consistencia en distintos hardwares y aumentados los valores de ParallaxEffect.
        transform.position = new Vector3(transform.position.x - parallaxEffect*Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.localPosition.x < -20)
        {
            transform.localPosition = new Vector3(20, transform.localPosition.y, transform.localPosition.z);
        }

        StopParallax();
    }

    public void StopParallax()
    {
        if (Controller_Hud.gameOver == true)
        {
            parallaxEffect = 0; /*Siendo esta variable el coeficiente que "empuja" hacia la izquierda los assets del fondo,
                                 se iguala a cero para detenerlos por completo*/ 
        }
    }
}
