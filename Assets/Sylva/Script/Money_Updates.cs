using TMPro;
using UnityEngine;

public class Money_Updates : MonoBehaviour
{
    public static Money_Updates main;

    [SerializeField] private GameObject levelManager;

    public TMP_Text currentMoneyNum;
    public TMP_Text currentWaveCost;

    private void Awake()
    {
        main = this;
    }

    public void Start()
    {
        levelManager = FindFirstObjectByType<LevelManager>().gameObject;
        main.currentMoneyNum.text = main.levelManager.GetComponent<Money>().currentMoney.ToString();
        main.currentWaveCost.text = main.levelManager.GetComponent<Money>().waveCost.ToString();
    }

    public void Update()
    {
        main.currentMoneyNum.text = main.levelManager.GetComponent<Money>().currentMoney.ToString();
        main.currentWaveCost.text = main.levelManager.GetComponent<Money>().waveCost.ToString();
    }
}
