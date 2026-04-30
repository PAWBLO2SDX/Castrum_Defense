using UnityEngine;

public class Money : MonoBehaviour
{

    public static Money main;

 
    [Header("References")]
    [SerializeField] private GameObject levelManager;
    [SerializeField] private GameObject shopPrefab;
    [SerializeField] private GameObject MoneyBackGround;
    [SerializeField] private Transform shopSpawn;
    [Header("Variables")]
    [SerializeField] private float startingMoney;

    public float currentMoney;
    public float waveCost = 200f;
    private bool shopSpawned = false;
    public bool ShopSpawned => shopSpawned;
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
        if (num == 1 && Money.main.currentMoney >= 100)
        {
            main.currentMoney -= 100f;
            BuildManager.main.SetSelectedTower(0);
            BuildManager.main.IncreaseTower();
        }
        else if (num == 2 && Money.main.currentMoney >= 250)
        {
            main.currentMoney -= 250f;
            BuildManager.main.SetSelectedTower(1);
            BuildManager.main.IncreaseTower();
        }
        else if (num == 3 && Money.main.currentMoney >= 200)
        {
            main.currentMoney -= 200f;
            BuildManager.main.SetSelectedTower(2);
            BuildManager.main.IncreaseTower();
        }
        else if (num == 4 && Money.main.currentMoney >= 400)
        {
            main.currentMoney -= 400f;
            BuildManager.main.SetSelectedTower(3);
            BuildManager.main.IncreaseTower();
        }
        else if (num == 5 && Money.main.currentMoney >= 750)
        {
            main.currentMoney -= 750f;
            BuildManager.main.SetSelectedTower(4);
            BuildManager.main.IncreaseTower();
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
