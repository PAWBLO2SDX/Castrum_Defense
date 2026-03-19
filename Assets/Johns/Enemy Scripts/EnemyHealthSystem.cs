using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;

public class EnemyHealthSystem : MonoBehaviour
{
    public int health;

    private Vector3 _targetPosition;

    private int _currentWaypoint = 0;

    public float maxHealth = 100f;

    private float currentHealth;

    private Path currentPath;

    public static Action<EnemyHealthSystem> OnEnemyReachedEnd { get; internal set; }

    private void Awake()
    {

        GameObject pathObject = GameObject.Find("Path1");
        if (pathObject != null)
        {
          //  currentPath = pathObject.GetComponent<Path>();
        }
        else
        {
            Debug.LogError("Path1 GameObject not found in the scene.");
        }

    }
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void OnEnable()
    {

      _currentWaypoint= 0;
      //  Vector3 vector3 = currentPath.GetPosition(_currentWaypoint);
       // _targetPosition = vector3;

    }
    public void TakeDamage(float damage)
    {

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {

        // Move towards the target position
       // transform.position = Vector3.MoveTowards(transform.position, _targetPosition, movementSpeed * Time.deltaTime);
       // movementSpeed += 0.01f;
        // Check if the enemy has reached the target position
        float relativeDistance = (transform.position - _targetPosition).magnitude;
        if (relativeDistance < 0.1f)
        {
            _currentWaypoint++;
            if (_currentWaypoint < 5)
            {
             //   _targetPosition = currentPath.GetPosition(_currentWaypoint);
            }
            else
            {
                //Enemy has reached the end of the path, you can handle it here (e.g., damage the player, destroy the enemy, etc.)
                Destroy(gameObject);
            }
        }

    }

 
}
