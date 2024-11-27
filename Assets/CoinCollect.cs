using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private Animator animator; // ������ �� ��������� Animator
    private bool isCollected = false; // ���� ��� �������������� ���������� �����

    void Start()
    {
        // �������� ��������� Animator
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        // ���������, ��� ������ ����� ��� "Player" � ������ ��� �� �������
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true; // ������������� ����
            animator.SetTrigger("Collect"); // ��������� �������� �����
            Debug.Log("Coin collected!");

            // ����������� ���������� ����� � ��������
            Wallet.Instance.AddCoin();
        }
    }

    // ���� ����� ���������� �������� ��������
    public void DestroySelf()
    {
        Destroy(gameObject); // ���������� ������ ������
    }
}
