using System.Collections;
using UnityEngine;

public class SlowBullet : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private LayerMask enemyMask;
    private Transform target;
    
    [Header("Attributes")]
    [SerializeField] private float bulletspeed = 10f;
    [SerializeField] private int bulletDamage = 1;

    [Header("Slow Effect")]
    [SerializeField] private float slowMultiplier = 0.5f; 
    [SerializeField] private float slowDuration = 1f; 

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit(collision.collider.gameObject);
    }

    private void HandleHit(GameObject otherObj)
    {
        if (otherObj == null) return;
        
        Health health = otherObj.GetComponent<Health>() ?? otherObj.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(bulletDamage);
        }

        
        EnemyMovement movement = otherObj.GetComponent<EnemyMovement>() ?? otherObj.GetComponentInParent<EnemyMovement>();
        if (movement != null)
        {
            int modifierId = movement.AddSpeedModifier(slowMultiplier);
            StartCoroutine(RemoveSpeedModifierAfter(movement, modifierId, slowDuration));
        }

        Destroy(gameObject);
    }

    private IEnumerator RemoveSpeedModifierAfter(EnemyMovement movement, int id, float duration)
    {
        yield return new WaitForSeconds(duration);
        if (movement != null)
        {
            movement.RemoveSpeedModifier(id);
        }
    }
}
