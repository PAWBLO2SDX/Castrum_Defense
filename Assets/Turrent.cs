using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq.Expressions;

public class Turrent : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turrentRotationPoint;
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float targetingRange= 5f;
    [SerializeField] private float rotationSpeed = 5f;
    private Transform target;

    private void Update()
    {

        if (target != null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

       if(!CheckTargetIsInRange())
        {
            target = null;
        }
    }


    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2) transform.up, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
            Vector3 direction = target.position - turrentRotationPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            turrentRotationPoint.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else
        {
            target = null;
        }
    }


    private bool CheckTargetIsInRange()
    {
      return  Vector2.Distance(transform.position, target.position) <= targetingRange;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - turrentRotationPoint.position.y, target.position.x - turrentRotationPoint.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turrentRotationPoint.rotation = Quaternion.RotateTowards(turrentRotationPoint.rotation,targetRotation, rotationSpeed * Time.deltaTime);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }
}

