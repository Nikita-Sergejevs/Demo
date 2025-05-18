using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowStats : MonoBehaviour, IDamageable
{
    [SerializeField] private WindowData data;

    public float health;
    private float hpRegen;

    private void Start()
    {
        if (data == null)
            return;

        var config = CreateWindowConfig();

        health = config.hp;
        hpRegen = config.hpRegen;
    }

    private WindowConfig CreateWindowConfig()
    {
        var config = ScriptableObject.CreateInstance<WindowConfig>();
        config.hp = data.baseHp;
        config.hpRegen = data.baseHpRegen;

        return config;
    }

    public bool TryToRepair()
    {
        return health < data.baseHp;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            WindowDestroy();
    }

    public void GetRepair()
    {
        health = Mathf.Min(health += hpRegen, data.baseHp);
    }

    private void WindowDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }
}