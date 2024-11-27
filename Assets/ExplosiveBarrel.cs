using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public GameObject explosionEffect; // Префаб взрыва
    public float explosionForce = 500f;
    public float explosionRadius = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Проверяем, игрок ли это
        {
            Explode();
        }
    }

    void Explode()
    {
        // Создаём эффект взрыва
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Применяем силу взрыва к окружающим объектам
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // Уничтожаем бочку
        Destroy(gameObject);
    }
}
