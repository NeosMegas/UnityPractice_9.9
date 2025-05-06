using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float initialTimeToExplosion;
    public float TimeToExplosion;
    public float Power;
    public float Radius;
    bool exploded = false;
    /// <summary>
    /// ‘лаг, позвол€ющий "перезар€дить" взрыв во врем€ игры
    /// </summary>
    public bool RechargeExplosive = false;

    void Start()
    {
        initialTimeToExplosion = TimeToExplosion;
    }

    void Update()
    {
        if (RechargeExplosive)
        {
            RechargeExplosive = false;
            exploded = false;
            TimeToExplosion = initialTimeToExplosion;
        }
        if (exploded) return;
        TimeToExplosion -= Time.deltaTime;
        if ( TimeToExplosion <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        if (exploded) return;
        Rigidbody[] bodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            float distance = Vector3.Distance(transform.position, rb.transform.position);
            if (distance < Radius)
            {
                Vector3 direction = rb.transform.position - transform.position;
                rb.AddForce(direction.normalized * Power * (Radius - distance), ForceMode.Impulse);
            }
        }
        exploded = true;
    }
}
