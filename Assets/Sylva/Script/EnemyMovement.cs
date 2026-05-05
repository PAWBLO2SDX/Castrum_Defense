using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement main;
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject levelManager;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float moveSpeed; // change this value in the Unity editor for the enemy prefabs since they'll have varying speeds

    private Transform target; // the target path object that the enemy will be moving to
    private int pathIndex = 0;
    private float baseSpeed; // stores the original speed of the enemy
    private readonly Dictionary<int, float> speedModifiers = new Dictionary<int, float>();
    private int modifierCounter = 0;

    private void Awake()
    {
        baseSpeed = moveSpeed;
    }

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            //float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg -180;
            //Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            //gameObject.transform.rotation = targetRotation;

            

            if (pathIndex >= LevelManager.main.path.Length)
            {
                Debug.Log("final path check");
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                Vector3 normalized = (LevelManager.main.path[pathIndex].position - LevelManager.main.path[pathIndex - 1].position).normalized;
                Vector3 newVec = normalized;
                transform.up = newVec;
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    // Legacy: sets an absolute speed
    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    // Reset to original base speed and clear modifiers
    public void ResetSpeed()
    {
        speedModifiers.Clear();
        moveSpeed = baseSpeed;
    }

    // Adds a multiplicative speed modifier and returns an id to remove it later.
    // Example: multiplier = 0.5f halves speed.
    public int AddSpeedModifier(float multiplier)
    {
        modifierCounter++;
        speedModifiers[modifierCounter] = multiplier;
        RecalculateSpeed();
        return modifierCounter;
    }

    // Removes modifier by id and recalculates speed
    public void RemoveSpeedModifier(int id)
    {
        if (speedModifiers.Remove(id))
        {
            RecalculateSpeed();
        }
    }

    private void RecalculateSpeed()
    {
        float mul = 1f;
        foreach (var m in speedModifiers.Values)
        {
            mul *= m;
        }
        moveSpeed = baseSpeed * mul;
    }
}
