using UnityEngine;

public class WeaponConfig : ScriptableObject
{
    public string weaponName;

    public float damage;
    public float fireRate;
    public float distance;

    public float magSize;
    public float magCount;
    public float totalAmmo;

    public AmmoData ammoType;

    public LayerMask layerMask;

    public bool canShoot;
}