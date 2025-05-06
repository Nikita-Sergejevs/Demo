using UnityEngine;

public class StandingBehavior : MonoBehaviour, IEnemyBehavior, IDamageTaken
{
    private float lifeTime;

    private bool hasKilledPlayer;

    private Enemy enemy;

    public void InitializeBehavior(EnemyBehaviorConfig config)
    {
        enemy = GetComponent<Enemy>();

        lifeTime = config.lifeTime;

        OnSpawn();
    }

    private void OnEnable()
    {
        Windows.OnEndShootFromWindow += OnPlayerAction;
    }

    private void OnDisable()
    {
        Windows.OnEndShootFromWindow -= OnPlayerAction;
    }

    private void OnPlayerAction()
    {
        if (!hasKilledPlayer && enemy != null)
        {
            Debug.Log("killed");
            hasKilledPlayer = true;

            GoAway();
        }
    }

    public void OnTakeDamage(float currentHp, float maxHp)
    {
        if (currentHp < maxHp && !hasKilledPlayer) 
        {
            Debug.Log("killed");
            hasKilledPlayer = true;

            GoAway();
        }
    }

    private void OnSpawn()
    {
        hasKilledPlayer = false;

        Invoke(nameof(GoAway), lifeTime);
    }

    private void GoAway()
    {
        EnemyWindowUtil.ResetSpawn();
        enemy.Die();
    }
}