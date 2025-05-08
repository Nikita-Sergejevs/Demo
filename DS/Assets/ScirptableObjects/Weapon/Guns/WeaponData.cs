using UnityEngine;

[CreateAssetMenu (fileName = "Weapon", menuName = "Weapon/New Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Info")]
    public string weaponName;

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
    public AmmoData ammoType;

    [HideInInspector]
    public bool canShoot;
}