using UnityEngine;

public class PlayerConfig : ScriptableObject
{
    public float speed;

    [SerializeField] private int money;

    public int Money
    {
        get => money;
        set => money = Mathf.Max(0, value);
    }

    public void AddMoney(int amount) => Money += amount;
    public bool SpendMoney(int amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            return true;
        }
        return false;
    }
}