using System.Collections;
using UnityEngine;
using UnityEditor;

public class TurrentSoaker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float aps = 4f; // attack per second
    [SerializeField] private float freezeTime = 1f; // Duration of the freeze effect
    private float timeUntilFire;

    private void Update()
    {
        timeUntilFire += Time.deltaTime;
        if (timeUntilFire >= 1f / aps)
        {
            FreezeEnemies();
                        timeUntilFire = 0f;
        }
    }

    private void FreezeEnemies()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.up, 0f, enemyMask);

        if (hits.Length > 0)
        {
          for (int i = 0; i < hits.Length; i++) 
            {
                RaycastHit2D hit = hits[i];

                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();
                em.UpdateSpeed(0.5f); // Reduce speed to 50% of original
                StartCoroutine(ResetEnemySpeed(em)); // Reset speed after freezeTime
            }
        }
    }
       
    private IEnumerator ResetEnemySpeed(EnemyMovement em)
    {
        yield return new WaitForSeconds(freezeTime); // Freeze duration
    }
    
       private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, Vector3.forward, targetingRange);
    }


}
