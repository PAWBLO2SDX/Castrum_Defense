using TMPro;
using UnityEngine;

public class Plr_hp_upd : MonoBehaviour
{
    public static Plr_hp_upd main;
    public TMP_Text hp_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        main.hp_text.text = PlayerHealth.main.health.ToString();
    }

    private void Awake()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        main.hp_text.text = PlayerHealth.main.health.ToString();
    }
}
