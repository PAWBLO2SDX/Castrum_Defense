using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth main;


    [Header("Attributes")]
    [SerializeField] public int health = 50;

    private void Awake()
    {
        main = this;
    }

    public void takeDamage()
    {
        main.health = main.health - 1;
    }

    public int getHealth()
    {
        return main.health;
    }
}
