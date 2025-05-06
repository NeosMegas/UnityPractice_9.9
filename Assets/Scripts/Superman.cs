using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    public float acceleraiton = 10;
    public float strikeForce = 10;
    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        body.AddForce(acceleraiton, 0, 0, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherBody = collision.gameObject.GetComponent<Rigidbody>();
        if (otherBody != null && collision.gameObject.layer == 8)
        {
            Vector3 force = (otherBody.position - body.position) * strikeForce;
            otherBody.AddForce(force, ForceMode.Impulse);
        }
    }
}
