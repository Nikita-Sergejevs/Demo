using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowStats : MonoBehaviour, IDamageable
{
    [SerializeField] private WindowData data;

    private WindowRepair windowRepair;
    private WindowConfig windowConfig;

    private void Start()
    {
        if (data == null)
            return;

        windowConfig = ScriptableObject.CreateInstance<WindowConfig>();
        windowConfig.hp = data.baseHp;
        windowConfig.hpRegen = data.baseHpRegen;

        windowRepair = GetComponent<WindowRepair>();
        windowRepair.InitializeConfig(windowConfig, data);
    }

    public void TakeDamage(float damage)
    {
        windowConfig.hp -= damage;
        if (windowConfig.hp <= 0)
            WindowDestroy();
    }

    private void WindowDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }
}