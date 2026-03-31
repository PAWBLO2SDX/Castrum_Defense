using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;
    public bool shopOpen;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        shopOpen = false;
    }
}
