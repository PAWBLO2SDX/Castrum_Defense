using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Rigidbody2D rb;
    private Transform target;
    private GameObject owner;

    [Header("Attributes")]
    [SerializeField] private float bulletspeed = 10f;
    [SerializeField] private int bulletDamage = 1;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform _target, GameObject _owner = null)
    {
        target = _target;
        owner = _owner;
    }

    private void FixedUpdate()
    {
        if (!target) return;
        Vector2 direction = (target.position - transform.position).normalized;
              rb.linearVelocity = direction * bulletspeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleHit(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit(collision.collider.gameObject);
    }

    private void HandleHit(GameObject otherObj)
    {
        if (otherObj == null) return;

        // Ignore collisions with the bullet owner (or owner's children)
        if (owner != null)
        {
            if (otherObj == owner) return;
            if (otherObj.transform.IsChildOf(owner.transform)) return;
        }

        Health health = otherObj.GetComponent<Health>() ?? otherObj.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(bulletDamage);
        }

        Destroy(gameObject);
    }
}
