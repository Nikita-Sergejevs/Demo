using UnityEngine;

public class WeaponReference : MonoBehaviour, IWeaponProvider
{
    [SerializeField] private WeaponStateController controller;

    public WeaponStateController GetWeaponController()
    {
        return controller;
    }
}