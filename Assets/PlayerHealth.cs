using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // ������������ ��������
    private int currentHealth; // ������� ��������

    void Start()
    {
        currentHealth = maxHealth; // ������������� �������� �� ��������
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // ��������� ��������
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // ���������� ������
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        Destroy(gameObject); // ���������� ������ ������
    }
}