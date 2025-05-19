using UnityEngine;

public class WindowRepair : MonoBehaviour
{
    private WindowConfig windowConfig;
    private WindowData data;

    public void InitializeConfig(WindowConfig config, WindowData data)
    {
        this.windowConfig = config;
        this.data = data;
    }

    public bool CheckForRepair()
    {
        return windowConfig.hp < data.baseHp;
    }

    public void GetRepair()
    {
        windowConfig.hp = Mathf.Min(windowConfig.hp + windowConfig.hpRegen, data.baseHp);   
        Debug.Log(windowConfig.hp);
    }
}