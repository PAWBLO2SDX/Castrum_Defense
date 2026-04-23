using UnityEngine;
using System.Collections.Generic;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;
    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private GameObject[] levelManager;

    public List<GameObject> towerList = new();
    private int selectedTower;

    public static BuildManager Main { get => main; set => main = value; }

    private void Awake()
    {
        Main = this;
    }

    public GameObject GetSelectedTower()
    {
        return towerPrefabs[selectedTower];
    }

    public int GetPlaceableTowers() => Main.towerList.Count;

    public void LowerTower()
    {
        Main.towerList.Remove(Main.towerList[^1]);
    }

    public void IncreaseTower()
    {
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
