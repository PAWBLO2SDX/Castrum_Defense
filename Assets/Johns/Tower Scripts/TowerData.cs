using UnityEngine;

[CreateAssetMenu(fileName = "TowerProjectiles", menuName = "ScriptableObjects/TowerProjectiles", order = 1)]
public class TowerData : ScriptableObject
{
    public float range;
    public float shootInterval;
    public float projectileSpeed;
    public float projectileDuration;
    public float damage;

}
