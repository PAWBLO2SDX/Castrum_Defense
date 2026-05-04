using TMPro;
using UnityEngine;

public class Money_Upd2 : MonoBehaviour
{
    public static Money_Upd2 main;

    [SerializeField] private GameObject levelManager;

    public TMP_Text currentMoneyNum;
    public TMP_Text currentTileCost;

    private void Awake()
    {
        main = this;
    }

    public void Start()
    {
        levelManager = LevelManager.main.gameObject;
        main.currentMoneyNum.text = Money.main.currentMoney.ToString();
        main.currentTileCost.text = Plot.tileCost.ToString();
    }

    public void Update()
    {
        main.currentMoneyNum.text = Money.main.currentMoney.ToString();
        main.currentTileCost.text = Plot.tileCost.ToString();
    }
}
