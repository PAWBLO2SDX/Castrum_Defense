using System.Diagnostics;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text MoneyText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text waveText;
    private void UpdateWaveText(int currentWave)
    {
        waveText.text = $"Wave:{currentWave + 1}";
    }

    private void UpdateLivesText(int currentLives)
    {
        livesText.text = $"Lives:{currentLives}";
    }

    private void OnEnable()
    {



    }

    
}
