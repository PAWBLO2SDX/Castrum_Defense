using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Rigidbody2D rb;
    private  Transform target;
    [Header("Attributes")]
    [SerializeField] private float bulletspeed = 10f;

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
    private void OnCollisionEnter(Collision other )
    {
        //TAKE HEALTH FROM ENEMY
       Destroy (gameObject);
    }
}
