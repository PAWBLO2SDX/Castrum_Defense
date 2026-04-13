using UnityEngine;

public class Money : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject levelManager;
    [SerializeField] private GameObject shopPrefab;
    [SerializeField] private Transform shopSpawn;
    [Header("Variables")]
    [SerializeField] private int startingMoney;

    [HideInInspector] public int currentMoney;
    [HideInInspector] public bool shopSpawned;

    //need something for buying towers and adding them to the list of tower prefabs

    public void OpenShop()
    {
        Debug.Log("shop open");
        shopSpawned = true;
        levelManager.GetComponent<LevelManager>().shopOpen = true;
        GameObject shopObject = Instantiate(shopPrefab, shopSpawn.position, Quaternion.identity);
        shopObject.transform.SetParent(GameObject.FindGameObjectWithTag("Shop").transform, false);
    }
}
