using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(0);
        Debug.Log("Du døde!");
        // Her kan du lave restart, animation osv.
    }
}
