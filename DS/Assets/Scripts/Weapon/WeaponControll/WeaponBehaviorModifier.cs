using UnityEngine;
using weaponSystem;

public class WeaponBehaviorModifier : MonoBehaviour
{
    [SerializeField] private WeaponDataProvider weapon;
    [SerializeField] private WeaponMoveSwayBob swayBob;

    private void OnEnable()
    {
        WindowInteraction.OnShootFromWindow += EnableShooting;
        WindowInteraction.OnEndShootFromWindow += DisableShooting;
    }

    private void OnDisable()
    {
        WindowInteraction.OnShootFromWindow -= EnableShooting;
        WindowInteraction.OnEndShootFromWindow -= DisableShooting;
    }

    private void EnableShooting()
    {
        SetShootingState(true);
    }

    private void DisableShooting()
    {
        SetShootingState(false);
    }

    private void SetShootingState(bool enable)
    {
        weapon.Controller.SetCanShoot(enable);
        swayBob.enabled = !enable;
    }
}