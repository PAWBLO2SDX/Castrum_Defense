using Unity.VisualScripting;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject dimPrefab;
    [SerializeField] private GameObject levelManager;
    [Header("Variable")]
    [SerializeField] private bool shopTile;

    private GameObject tower;
    private GameObject hoverDimmer;
    private GameObject dimmer;
    [HideInInspector] public bool tileBought = false;
    public static float tileCost = 0f;
    public static int numTilesBought = 0;

    private void OnMouseEnter()
    {
        if (tileBought)
        {
            hoverDimmer = Instantiate(dimPrefab, transform.position, Quaternion.identity);
        }
        
    }

    private void Start()
    {
        if (shopTile)
        {
            tileBought = true;
        }

        if (!tileBought)
        {
            dimmer = Instantiate(dimPrefab, transform.position, Quaternion.identity);
        }
        
    }

    private void Update()
    {
        if (tileBought)
        {
            if (dimmer != null)
            {
                Destroy(dimmer);
            }
        }
    }

    private void OnMouseExit()
    {
        if (hoverDimmer != null)
        {
            Destroy(hoverDimmer);
        }
    }

    private void OnMouseDown()
    {
        //this is gonna be where we check if the plot is purchased and such using the Money script. This will be a nightmare

        if (tileBought == true)
        {
            if (shopTile && !FindFirstObjectByType<Money>().shopSpawned)
            {
                levelManager.GetComponent<Money>().OpenShop();
            }
            else if (shopTile && FindFirstObjectByType<Money>().shopSpawned)
            {
                levelManager.GetComponent<Money>().CloseShop();
            }
            else
            {
                if (!levelManager.GetComponent<Money>().shopSpawned)
                {
                    if (tower != null || BuildManager.main.GetPlaceableTowers() == 0) return;
                    GameObject towerToBuild = BuildManager.main.GetTowerList()[^1];
                    tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
                }
            }
        }
        else
        {
            if (FindFirstObjectByType<Money>().currentMoney >= tileCost && !FindFirstObjectByType<Money>().shopSpawned)
            {
                Debug.Log("buy check");
                tileBought = true;
                FindFirstObjectByType<Money>().currentMoney -= tileCost;
                if (numTilesBought == 0)
                {
                    tileCost += 200f;
                }
                else
                {
                    tileCost = tileCost * 2;
                }
                    numTilesBought++;
            }
        }
        
    }
}
