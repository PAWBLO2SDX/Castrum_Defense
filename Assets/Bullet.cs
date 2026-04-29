using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Rigidbody2D rb;
    private Transform target;
    [Header("Attributes")]
    [SerializeField] private float bulletspeed = 10f;
    [SerializeField] private int bulletDamage = 10;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (!target) return;
        Vector2 direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * bulletspeed;
    }

    // Use 2D trigger callback. Make the bullet collider "Is Trigger" in the inspector,
    // or switch to OnCollisionEnter2D + Collision2D if you want non-trigger collisions.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null) return;

        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(bulletDamage);
        }

        Destroy(gameObject);
    }
}
