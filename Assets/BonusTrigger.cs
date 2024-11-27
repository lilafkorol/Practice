using UnityEngine;

public class BonusTrigger : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Activate");
            Debug.Log("Player activated the bonus animation!");
        }
    }
}


