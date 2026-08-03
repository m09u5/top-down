using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float objectHealth = 100;
    private float currentHealth;

    [SerializeField] private DeathHandler deathHandler;

    private void Awake()
    {
        currentHealth = objectHealth;
    }

    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
             Death();
        }

        
    }
    [ContextMenu("damage")]
    private void test()
    {
        TakeDamage(10f);
    }

    private void Death()
    {
        deathHandler.HandleDeath();
    }
}
