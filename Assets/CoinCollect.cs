using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private Animator animator; // Ссылка на компонент Animator
    private bool isCollected = false; // Флаг для предотвращения повторного сбора

    void Start()
    {
        // Получаем компонент Animator
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Проверяем, что объект имеет тег "Player" и монета еще не собрана
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true; // Устанавливаем флаг
            animator.SetTrigger("Collect"); // Запускаем анимацию сбора
            Debug.Log("Coin collected!");

            // Увеличиваем количество монет в кошельке
            Wallet.Instance.AddCoin();
        }
    }

    // Этот метод вызывается событием анимации
    public void DestroySelf()
    {
        Destroy(gameObject); // Уничтожаем объект монеты
    }
}
