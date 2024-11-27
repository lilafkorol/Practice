using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения
    public float jumpForce = 5f; // Сила прыжка
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Получаем компонент Rigidbody при старте
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Обработка ввода для движения
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime;

        // Перемещение игрока
        transform.Translate(movement, Space.Self);

        // Прыжок, если игрок на земле
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Проверка, что игрок касается земли
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}