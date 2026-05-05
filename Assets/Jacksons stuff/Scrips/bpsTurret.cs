using UnityEngine;

public class bpsTurret : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }
}
