using UnityEngine;

public class deathCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Du døde!");
        // Her kan du lave restart, animation osv.
    }
}
