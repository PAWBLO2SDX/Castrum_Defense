using UnityEngine;
using System.Collections.Generic;

public class BuildManager : MonoBehaviour
{
    private static BuildManager main;
    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private GameObject[] levelManager;

    public List<GameObject> towerList = new();
    [SerializeField] private int placeableTowers = 0;
    private int selectedTower;

    public static BuildManager Main { get => main; set => main = value; }

    private void Awake()
    {
        Main = this;
    }

    public int GetPlaceableTowers()
    {
        return placeableTowers;
    }

    public void LowerTower()
    {
        Main.placeableTowers--;
        Main.towerList.Remove(Main.towerList[^1]);
    }

    public void IncreaseTower()
    {
        Main.placeableTowers++;
        Main.towerList.Add(Main.towerPrefabs[Main.selectedTower]);
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
