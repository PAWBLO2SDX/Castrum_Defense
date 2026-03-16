using UnityEngine;
using System.Collections;
public class Tower : MonoBehaviour
{
    [SerializeField] private TowerData data;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, data.range);
    }
}
