using UnityEngine;

public class FloatAnimation : MonoBehaviour
{
    public float amplitude = 0.2f;
    public float frequency = 1f;

    private float startY;

    void Start()
    {
        startY = transform.localPosition.y;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * frequency) * amplitude;

        // Kun Y ændres – X og Z forbliver som ObstacleMovement sætter dem
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            startY + y,
            transform.localPosition.z
        );
    }
}
