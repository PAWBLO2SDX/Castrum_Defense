using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _lives = 20;

    private void OnEnable()
    {
       // EnemyHealthSystem.OnEnemyReachedEnd += HandleEnemyReachedEnd;
    }

    private void HandleEnemyReachedEnd(EnemyHealthSystem enemy)
    {
       
    }
}
