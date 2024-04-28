using TMPro;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
    private float initialSize;
    private int i = 0;
    private bool floored;
    private bool shielded;
    private Renderer playerRender;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSize = rb.transform.localScale.y;
        shielded = false;
        playerRender = GetComponent<Renderer>();
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        Jump();
        Duck();
    }

    private void Jump()
    {
        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    private void Duck()
    {
        if (floored)
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (i == 0)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++;
                }
            }
            else
            {
                if (rb.transform.localScale.y != initialSize)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!shielded)
            {
                Destroy(this.gameObject);
                Controller_Hud.gameOver = true;
            }
            else shielded = false;
            playerRender.material.SetColor("_Color", Color.blue);
            /*Como los enemigos no son triggers, habrá un contacto físico con el jugador.
            Si convirtiera a todos en triggers, debería programar unos segundos de invunerabilidad
            para que el código del TriggerEnter no se ejecute inmediatamente de nuevo y cause
            la muerte del jugador*/
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = true;
        }

        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Shield"))
        {
            shielded = true;
            Destroy(collider.gameObject);
            playerRender.material.SetColor("_Color", Color.green);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = false;
        }
    }
}
