using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public static float enemyVelocity;
    internal Rigidbody rb;

    void Awake() //Si no uso Awake acá, me tira una NullException al momento de instanciar el enemigo púrpura.
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void FixedUpdate()
        /*Cambié Update por FixedUpdate para que el Addforce fuera consistente en distintos
         hardwares respecto a la tasa de frames. Si usaba un Time.deltaTime en el update común,
         el método no funcionaba del todo bien.*/
    {
        rb.AddForce(new Vector3(-enemyVelocity, 0, 0), ForceMode.Force);
        OutOfBounds();
    }

    public void OutOfBounds()
    {
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}
