using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static PlayerContext playerContext {  get; private set; }

    [SerializeField] private PlayerWallet wallet;
    [SerializeField] private WeaponDataProvider dataProvider;

    private void Awake()
    { 
        playerContext = new PlayerContext()
        {
            playerWallet = wallet,
            weaponDataProvider = dataProvider,
            playerInventory = new PlayerInventory()
        };
    }
}