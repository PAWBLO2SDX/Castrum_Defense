using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class TurrentSoaker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turrentRotationPoint;
    [SerializeField] private Rigidbody2D turretRigidbody;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float aps = 4f; // attack per second
    [SerializeField] private float freezeTime = 1f; // Duration of the freeze effect
    [SerializeField] private float turnSpeed = 720f; // degrees per second
    [SerializeField] private float angleOffset = -90f; // adjust to match sprite forward
    private Transform target;


    private float timeUntilFire;
    private float desiredAngle;

    private void Start()
    {
        // try auto-assign if not set in Inspector
        if (turrentRotationPoint != null && turretRigidbody == null)
            turretRigidbody = turrentRotationPoint.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // compute aiming target each frame
        ComputeDesiredAngleToNearestEnemy();

        timeUntilFire += Time.deltaTime;
        if (timeUntilFire >= 1f / aps)
        {
            FreezeEnemies();
            timeUntilFire = 0f;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / aps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }

    }

    private void Shoot()
    {
        GameObject bulletobj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bullet = bulletobj.GetComponent<Bullet>();
        bullet.SetTarget(target);
    }
    private GameObject Instantiate(GameObject bulletPrefab, Vector3 position, object indentity)
    {
        throw new NotImplementedException();
    }

    private void FixedUpdate()
    {
        // apply rotation using physics-friendly API
        if (turrentRotationPoint == null) return;

        if (turretRigidbody != null)
        {
            // MoveRotation expects degrees. Use MoveTowardsAngle for smooth rotation.
            float current = turretRigidbody.rotation;
            float newZ = Mathf.MoveTowardsAngle(current, desiredAngle, turnSpeed * Time.deltaTime);
            turretRigidbody.MoveRotation(newZ);
        }
        else
        {
            // fallback if no Rigidbody2D present
            Quaternion targetRot = Quaternion.Euler(0f, 0f, desiredAngle);
            turrentRotationPoint.rotation = Quaternion.RotateTowards(turrentRotationPoint.rotation, targetRot, turnSpeed * Time.deltaTime);
        }
    }

    private void ComputeDesiredAngleToNearestEnemy()
    {
        if (turrentRotationPoint == null) return;

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, targetingRange, enemyMask);
        if (cols == null || cols.Length == 0)
            return;

        Transform closest = null;
        float minDist = float.MaxValue;
        Vector3 origin = turrentRotationPoint.position;

        foreach (var c in cols)
        {
            if (c == null) continue;
            float d = (c.transform.position - origin).sqrMagnitude;
            if (d < minDist)
            {
                minDist = d;
                closest = c.transform;
            }
        }

        if (closest == null) return;

        Vector3 dir = (closest.position - origin);
        if (dir.sqrMagnitude < 0.0001f) return;

        dir.Normalize();
        desiredAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
        Debug.DrawLine(origin, closest.position, Color.green);
    }

    private void FreezeEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, targetingRange, enemyMask);

        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                Collider2D col = colliders[i];
                if (col == null) continue;

                EnemyMovement em = col.GetComponent<EnemyMovement>();
                if (em == null) continue;

                int modifierId = em.AddSpeedModifier(0.5f); // apply 50% multiplier
                StartCoroutine(ResetEnemySpeed(em, modifierId)); // Reset modifier after freezeTime
            }
        }
    }

    private IEnumerator ResetEnemySpeed(EnemyMovement em, int modifierId)
    {
        yield return new WaitForSeconds(freezeTime); // Freeze duration
        if (em != null)
        {
            em.RemoveSpeedModifier(modifierId);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, Vector3.forward, targetingRange);
    }
}
