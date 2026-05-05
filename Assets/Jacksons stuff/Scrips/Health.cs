using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float hitPoints = 2f;

    [Header("Reward")]
    [SerializeField] private float rewardOnDeath = 10f;

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;
        if (hitPoints <= 0f)
        {
            if (Money.main != null)
            {
                Money.main.ManualMoneyIncrease(rewardOnDeath);
            }

            if (EnemySpawner.onEnemyDestroy != null)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
            }

            Destroy(gameObject);
        }
    }
}
