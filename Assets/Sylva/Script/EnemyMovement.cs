using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement main;
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject levelManager;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float moveSpeed; //change this value in the Unity editor for the enemy prefabs since they'll have varying speeds

    private Transform target; //the target path object that the enemy will be moving to
    private int pathIndex = 0;
    private float baseSpeed; //stores the original speed of the enemy, used for resetting speed after being slowed by the turrent soaker
    //allows tracking of which specific object the enemy is at along the path, if it reaches the last in the path index, then you take damage and the enemy dies

    private void Start()
    {
        baseSpeed = moveSpeed;
        target = LevelManager.main.path[pathIndex];
    }
    //selects the first point in the path to start moving towards

    private void Update()
    {

        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            //if statement checks if the pathIndex at its new value is past the last point in the pathway
            if (pathIndex >= LevelManager.main.path.Length)
            {
                //destroys the enemy object if true, as well as making the player take damage

                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
            }
            else
            {
                //sets the new target with the new pathIndex value
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {

        //sets the direction and moves towards the object in the path Array corresponding to the value of pathIndex

        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * moveSpeed;
    }
    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

     public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
