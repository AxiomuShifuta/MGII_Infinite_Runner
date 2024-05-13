using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Purple_Enemy : Controller_Enemy
{
    public float jumpForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    override public void FixedUpdate()
    {
        Jump();
        base.FixedUpdate();
    }

    public void Jump()
    {
        
        if (transform.position.x == -16f)
        {
            Debug.Log("J");
            rb.AddForce(new Vector3(rb.velocity.x, jumpForce, rb.velocity.z),ForceMode.VelocityChange);
            //Cambié tiempo por posición para disparar el salto, pero no funciona.
        } 
    }

}
