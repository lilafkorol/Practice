using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье
    private int currentHealth; // Текущее здоровье

    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем здоровье на максимум
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // Уменьшаем здоровье
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Уничтожаем игрока
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        Destroy(gameObject); // Уничтожаем объект игрока
    }
}
