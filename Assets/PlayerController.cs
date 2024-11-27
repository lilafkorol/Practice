using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ��������
    public float jumpForce = 5f; // ���� ������
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // �������� ��������� Rigidbody ��� ������
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ��������� ����� ��� ��������
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime;

        // ����������� ������
        transform.Translate(movement, Space.Self);

        // ������, ���� ����� �� �����
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // ��������, ��� ����� �������� �����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}