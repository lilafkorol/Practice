using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public GameObject explosionEffect; // ������ ������
    public float explosionForce = 500f;
    public float explosionRadius = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // ���������, ����� �� ���
        {
            Explode();
        }
    }

    void Explode()
    {
        // ������ ������ ������
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // ��������� ���� ������ � ���������� ��������
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // ���������� �����
        Destroy(gameObject);
    }
}
