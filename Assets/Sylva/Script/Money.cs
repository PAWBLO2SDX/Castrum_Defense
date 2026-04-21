using UnityEngine;

public class Money : MonoBehaviour
{

    public static Money main;

    [Header("References")]
    [SerializeField] private GameObject levelManager;
    [SerializeField] private GameObject shopPrefab;
    [SerializeField] private Transform shopSpawn;
    [Header("Variables")]
    [SerializeField] private float startingMoney;

    public float currentMoney;
    public float waveCost = 200f;
    [HideInInspector] public bool shopSpawned;
    private GameObject shopObject;

    //need something for buying towers and adding them to the list of tower prefabs

    private void Awake()
    {
        main = this;
    }

    public void OpenShop()
    {
        Debug.Log("shop open");
        main.shopSpawned = true;
        shopObject = Instantiate(shopPrefab, shopSpawn.position, Quaternion.identity);
        shopObject.transform.SetParent(GameObject.FindGameObjectWithTag("Shop").transform, false);
    }

    public void CloseShop()
    {
        Debug.Log("shop closed");
        main.shopSpawned = false;
        Destroy(shopObject);
    }

    public void BuyTower(int num)
    {
        if (num == 1)
        {
            levelManager.GetComponent<BuildManager>().SetSelectedTower(num - 1);
            levelManager.GetComponent<BuildManager>().IncreaseTower();
        }
    }

    public void BuyWave()
    {
        main.currentMoney -= waveCost;
        levelManager.GetComponent<EnemySpawner>().waveBought++;
        main.waveCost += 200f;
    }

    private void Start()
    {
        main.currentMoney = main.startingMoney;
    }

    public void ManualMoneyDecrease(float num)
    {
        currentMoney -= num;
    }
}
