using UnityEngine;

public class Money : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject levelManager;
    [Header("Variables")]
    [SerializeField] private int startingMoney;

    [HideInInspector] public int currentMoney;

    //need something for buying towers and adding them to the list of tower prefabs

    public void OpenShop()
    {
        Debug.Log("shop open");
        levelManager.GetComponent<LevelManager>().shopOpen = true;
    }
}
