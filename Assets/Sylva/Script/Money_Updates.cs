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
        levelManager = LevelManager.main.gameObject;
        main.currentMoneyNum.text = Money.main.currentMoney.ToString();
        main.currentWaveCost.text = Money.main.waveCost.ToString();
    }

    public void Update()
    {
        main.currentMoneyNum.text = Money.main.currentMoney.ToString();
        main.currentWaveCost.text = Money.main.waveCost.ToString();
    }
}
