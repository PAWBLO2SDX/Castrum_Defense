using UnityEngine;
using System.Collections.Generic;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private GameObject[] levelManager;

    public List<GameObject> towerList = new();
    [SerializeField] private int placeableTowers = 0;
    private int selectedTower;

    private void Awake()
    {
        main = this;
    }

    public int GetPlaceableTowers()
    {
        return placeableTowers;
    }

    public void LowerTower()
    {
        main.placeableTowers--;
        main.towerList.Remove(main.towerList[^1]);
    }

    public void IncreaseTower()
    {
        main.placeableTowers++;
        main.towerList.Add(main.towerPrefabs[main.selectedTower]);
    }

    public List<GameObject> GetTowerList()
    {
        return towerList;
    }

    public void SetSelectedTower(int num)
    {
        selectedTower = num;
    }
}
