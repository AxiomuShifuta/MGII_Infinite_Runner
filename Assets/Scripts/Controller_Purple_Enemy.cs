using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Purple_Enemy : Controller_Enemy
{
    public float jumptimer;
    private bool floored;
    public float jumpForce = 2;
    // Start is called before the first frame update
    void Start()
    {
        jumptimer = 3;
    }

    // Update is called once per frame
    override public void FixedUpdate()
    {
        Jump();
        base.FixedUpdate();
    }

    void Jump()
    {
        jumptimer -= Time.deltaTime;

        if (jumptimer <= 0 && floored)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

            jumptimer = 4;
           
        } /*Si activo la gravedad desde el inspector, el AddForce() del script Controller_Enemy no empuja al objeto.
           Si desactivo la gravedad, el objeto salta, pero nunca cae, lógicamente.*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = true;
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
