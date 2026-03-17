using FileHelpers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Serialize Field] private TMP_Text scoreText;
    [SerializeField] private TMP_Text waveText;

    public int UpdateWaveText { get; private set; }

    private void OnEnable()
    {
        EnemySpawner.OnWaveChanged + -UpdateWaveText;
    }


}
