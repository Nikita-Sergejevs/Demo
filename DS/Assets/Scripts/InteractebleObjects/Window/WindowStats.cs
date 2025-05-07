using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowStats : MonoBehaviour, IDamageable
{
    [SerializeField] private WindowData data;

    public float health;

    private void Start()
    {
        if (data == null)
            return;

        var config = CreateWindowConfig();
        
        health = config.hp;
    }

    private WindowConfig CreateWindowConfig()
    {
        var config = ScriptableObject.CreateInstance<WindowConfig>();
        config.hp = data.baseHp;

        return config;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            WindowDestroy();
    }

    private void WindowDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }
}