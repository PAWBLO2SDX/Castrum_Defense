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
        if (num == 1 && FindFirstObjectByType<Money>().currentMoney >= 100)
        {
            FindFirstObjectByType<Money>().currentMoney -= 100f;
            levelManager.GetComponent<BuildManager>().SetSelectedTower(0);
            levelManager.GetComponent<BuildManager>().IncreaseTower();
        }
        else if (num == 2 && FindFirstObjectByType<Money>().currentMoney >= 250)
        {
            FindFirstObjectByType<Money>().currentMoney -= 250f;
            levelManager.GetComponent<BuildManager>().SetSelectedTower(1);
            levelManager.GetComponent<BuildManager>().IncreaseTower();
        }
        else if (num == 3 && FindFirstObjectByType<Money>().currentMoney >= 200)
        {
            FindFirstObjectByType<Money>().currentMoney -= 200f;
            levelManager.GetComponent<BuildManager>().SetSelectedTower(2);
            levelManager.GetComponent<BuildManager>().IncreaseTower();
        }
        else if (num == 4 && FindFirstObjectByType<Money>().currentMoney >= 400)
        {
            FindFirstObjectByType<Money>().currentMoney -= 400f;
            levelManager.GetComponent<BuildManager>().SetSelectedTower(3);
            levelManager.GetComponent<BuildManager>().IncreaseTower();
        }
        else if (num == 5 && FindFirstObjectByType<Money>().currentMoney >= 750)
        {
            FindFirstObjectByType<Money>().currentMoney -= 750f;
            levelManager.GetComponent<BuildManager>().SetSelectedTower(4);
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

    public void ManualMoneyIncrease(float num)
    {
        currentMoney += num;
    }
}
