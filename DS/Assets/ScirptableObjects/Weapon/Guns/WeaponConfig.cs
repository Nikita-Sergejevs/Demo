using UnityEngine;

public class WeaponConfig : ScriptableObject
{
    public float damage;
    public float fireRate;
    public float distance;

    public float magSize;
    public float magCount;
    public float currentAmmo;
    public float maxTotalAmmo;

    public LayerMask layerMask;

    public bool canShoot;
}