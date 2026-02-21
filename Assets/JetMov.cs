using UnityEngine;
using UnityEngine.InputSystem; // vigtigt til det nye input system

public class JetMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minY = -4f;
    public float maxY = 4f;

    void Update()
    {
        float vertical = 0f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            vertical = 1f;

        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            vertical = -1f;

        Vector3 move = new Vector3(0, vertical, 0) * speed * Time.deltaTime;
        transform.position += move;

        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
