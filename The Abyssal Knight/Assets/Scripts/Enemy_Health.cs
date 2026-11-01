using UnityEngine;

public class Enemy_Health : MonoBehaviour
{ 

    public int currentHealth;
        public int maxHealth;

    private void Start()
    {
        currentHealth = maxHealth; 
    }

    public void ChnageHealth(int amount)
    {
        currentHealth += amount; 

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        else if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
