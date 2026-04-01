using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public Rigidbody2D projectilesRb;
    public float speed = 2.5f;
    public float range = 1;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = range;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        projectilesRb.angularVelocity = Vector2.right.x * speed;

        timer -= Time.deltaTime;

        if (timer <0)
        {
            Destroy(gameObject);
        }

    }


}
