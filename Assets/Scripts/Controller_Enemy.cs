using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public static float enemyVelocity;
    internal Rigidbody rb;

    void Awake() //Si no uso Awake acá, me tira una NullException al momento de instanciar el enemigo púrpura.
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Update()
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
