using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _lives = 20;
    private object data;
    private int datadamage;

    // Change the type from object to Action<int> to allow Invoke(_lives)
    public Action<int> OnLivesChanged { get; private set; }

    private void OnEnable()
    {
        EnemyHealthSystem.OnEnemyReachedEnd += HandleEnemyReachedEnd;
    }

    private void OnDisable()
    {
        EnemyHealthSystem.OnEnemyReachedEnd -= HandleEnemyReachedEnd;
    }

    private void HandleEnemyReachedEnd(EnemyHealthSystem enemy)
    {
        _lives -= datadamage;
        OnLivesChanged?.Invoke(_lives); 
    }
}
