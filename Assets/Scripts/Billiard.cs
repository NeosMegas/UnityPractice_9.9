using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billiard : MonoBehaviour
{
    Rigidbody body;
    public float strikeForce = 1f;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(strikeForce, 0, 0, ForceMode.Impulse);
    }

}
