using UnityEngine;

[CreateAssetMenu (fileName = "Weapon", menuName = "Weapon/New Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Shooting Parameters")]
    public float baseDamage;
    public float baseFireRate;
    public float baseShootDistance;
    [Space]
    public LayerMask layerMask;

    [Header("Ammo Parameters")]
    public float baseMagSize;
    public float baseMagCount;

    [Space]
    public UpgradeLimit[] upgradeLimits;

    [HideInInspector]
    public bool canShoot;
}

[System.Serializable]
public class UpgradeLimit
{
    public UpgradeTypes type;
    public int maxLevel;
    public float statsPerLevel;
}

public enum UpgradeTypes
{
    Damage,
    RPM,
    Ammo
}