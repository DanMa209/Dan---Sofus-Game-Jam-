using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -15f)
        {
            Destroy(gameObject); // fjerner obstacle når det er ude af skærmen
        }
    }
}
