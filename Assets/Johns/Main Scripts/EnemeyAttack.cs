using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyAttack : MonoBehaviour
{
    public int damage = 25;

    private void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.GetComponent<TowerHealth>())
        {
            collision.gameObject.GetComponent<TowerHealth>().health -= damage;
            Destroy(gameObject);
        }
    }

}
