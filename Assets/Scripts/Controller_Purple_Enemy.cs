using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Purple_Enemy : Controller_Enemy
{
    public float jumpForce = 2;
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

    void Jump()
    {
        
        if (transform.localPosition.x == -16)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            //Cambié tiempo por posición para disparar el salto, pero no funciona.

        } /*Si activo la gravedad desde el inspector, el AddForce() del script Controller_Enemy no empuja al objeto.
           Si desactivo la gravedad, el objeto salta, pero nunca cae, lógicamente.*/
    }

}
