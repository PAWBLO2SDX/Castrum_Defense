using System;
using Unity.VisualScripting;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject dimPrefab;
    [SerializeField] private GameObject towerToBuild;
    [SerializeField] private GameObject levelManager;
    [Header("Variable")]
    [SerializeField] private bool shopTile;

    private GameObject tower;
    private GameObject hoverDimmer;
    private GameObject dimmer;
    public bool tileBought = false;
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
            if (shopTile && !Money.main.ShopSpawned)
            {
                Money.main.OpenShop();
            }
            else if (shopTile && Money.main.ShopSpawned)
            {
                Money.main.CloseShop();
            }
            else
            {
                if (!Money.main.ShopSpawned)
                {
                    if (tower != null || BuildManager.main.GetPlaceableTowers() == 0) return;
                    GameObject towerToBuild = BuildManager.main.GetTowerList()[^1];
                    tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
                }
            }
        }
        else
        {
            if (Money.main.currentMoney >= tileCost && !Money.main.ShopSpawned)
            {
                Debug.Log("buy check");
                tileBought = true;
                Money.main.currentMoney -= tileCost;
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
        if (tower != null) return;
        {
            Tower towerToBuild = BuildManager.main.GetSelectedTower().GetComponent<Tower>();

           
        }
    }

 
}
