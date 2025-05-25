using UnityEngine;
using UnityEngine.SceneManagement;

public class StandingBehavior : MonoBehaviour, IEnemyBehavior
{
    private float lifeTime;

    private bool isDead;

    private Enemy enemy;

    public void InitializeBehavior(EnemyConfig config)
    {
        enemy = GetComponent<Enemy>();

        lifeTime = config.lifeTime;

        StartLifetimeTimer();
    }

    private void OnEnable()
    {
        WindowInteraction.OnWindowEnemyDespawn += KillFromWindowExit;
    }

    private void OnDisable()
    {
        WindowInteraction.OnWindowEnemyDespawn -= KillFromWindowExit;
    }

    private void StartLifetimeTimer()
    {
        Invoke(nameof(DissapearEnemy), lifeTime);
    }

    private void KillFromWindowExit()
    {
        if(isDead) return;

        isDead = true;
        CancelInvoke(nameof(DissapearEnemy));
        enemy.Die();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReactToHit()
    {
        if (isDead) return;

        KillFromWindowExit();
    }

    private void DissapearEnemy()
    {
        if (isDead) return;

        isDead = true;
        enemy.Die();
    }
}