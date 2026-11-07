using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int expReward = 3;
    // Way to send messages to signal enemy death. "Obeserv Pattern"
    // 1. Delegate = A constract that defines what info will be passed along 
    // 2. Event = Allows one pice of code to notify "listening" scripts when smt happens
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;

    public int currentHealth;
    public int maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        else if (currentHealth <= 0)
        {
            OnMonsterDefeated(expReward);
            Destroy(gameObject);
        }
    }
}
