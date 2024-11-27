using UnityEngine;
using TMPro; // ��� ������ � TextMeshPro

public class Wallet : MonoBehaviour
{
    public static Wallet Instance { get; private set; }

    private int coinCount = 0; // ������ ������� ���������� �����
    public TextMeshProUGUI coinText; // ������ �� UI ����� ��� ����������� ���������� �����

    private void Awake()
    {
        // ��������, ��� ������ Wallet �������� ����������
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ������ ����� �������
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI(); // ��������� UI ��� �������
    }

    public void AddCoin()
    {
        coinCount++; // ����������� ���������� �����
        UpdateUI(); // ��������� UI
    }

    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount; // ��������� ��������� ����
        }
    }

    public int GetCoinCount()
    {
        return coinCount; // ���������� ������� ���������� �����
    }
}
