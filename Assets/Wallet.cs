using UnityEngine;
using TMPro; // Для работы с TextMeshPro

public class Wallet : MonoBehaviour
{
    public static Wallet Instance { get; private set; }

    private int coinCount = 0; // Хранит текущее количество монет
    public TextMeshProUGUI coinText; // Ссылка на UI текст для отображения количества монет

    private void Awake()
    {
        // Убедимся, что объект Wallet является синглтоном
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект между сценами
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI(); // Обновляем UI при запуске
    }

    public void AddCoin()
    {
        coinCount++; // Увеличиваем количество монет
        UpdateUI(); // Обновляем UI
    }

    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount; // Обновляем текстовое поле
        }
    }

    public int GetCoinCount()
    {
        return coinCount; // Возвращаем текущее количество монет
    }
}
