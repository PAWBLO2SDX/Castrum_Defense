using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 10f;


    private Transform target;

    private void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    private void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;

        rb.linearVelocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision other)
    {
        Destroy(gameObject);
    }
}
