using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject dimPrefab;
    [SerializeField] private GameObject levelManager;
    [Header("Variable")]
    [SerializeField] private bool shopTile;

    private GameObject tower;
    private GameObject dimmer;
    [HideInInspector] public bool tileBought = false;

    private void OnMouseEnter()
    {
        dimmer = Instantiate(dimPrefab, transform.position, Quaternion.identity);
    }

    private void OnMouseExit()
    {
        Destroy(dimmer);
    }

    private void OnMouseDown()
    {
        //this is gonna be where we check if the plot is purchased and such using the Money script. This will be a nightmare

        if (shopTile)
        {
            levelManager.GetComponent<Money>().OpenShop();
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
}
