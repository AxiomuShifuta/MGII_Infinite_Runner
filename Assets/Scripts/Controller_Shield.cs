using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Shield : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       rb.velocity = new Vector3(-10, 0, 0);
    }
}
