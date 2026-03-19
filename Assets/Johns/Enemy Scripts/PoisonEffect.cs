using System.Collections;
using UnityEngine;

public class PoisonEffect : MonoBehaviour
{
    private bool isPoisoned = false;

    public void ApplyPoison(float duration, float tickRate, float damagePerTick)
    {
        if (!isPoisoned)
        {
            StartCoroutine(DoPoisonDamage(duration, tickRate, damagePerTick));
        }
    }

    IEnumerator DoPoisonDamage(float duration, float tickRate, float damagePerTick)
    {
        isPoisoned = true;
        float timer = 0f;

        // Loop for the total duration of the effect
        while (timer < duration)
        {
            // Apply damage every 'tickRate' seconds
            GetComponent<EnemyHealthSystem>()?.TakeDamage(damagePerTick);
            yield return new WaitForSeconds(tickRate);
            timer += tickRate;
        }

        isPoisoned = false;
    }
}
