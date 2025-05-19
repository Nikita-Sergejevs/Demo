using UnityEngine;

public interface IInteractable
{
    public bool CanHold();
    public void OnTap();
    public void OnHold();
}