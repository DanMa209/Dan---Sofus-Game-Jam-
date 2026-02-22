using UnityEngine;
using UnityEngine.InputSystem; // vigtigt til det nye input system

public class JetMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minY = -4f;
    public float maxY = 4f;

    public float tiltAmount = 15f;   // hvor meget flyet hælder
    public float tiltSpeed = 5f;     // hvor hurtigt flyet roterer
    public float glideSmooth = 3f;   // hvor hurtigt vertical glider mod 0

    float verticalSmooth = 0f;       // intern glidende værdi

    void Update()
    {
        float verticalInput = 0f;

        // Input
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            verticalInput = 1f;

        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            verticalInput = -1f;

        // --- SMOOTH GLIDE ---
        // Når man slipper tasterne, glider verticalSmooth langsomt mod 0
        verticalSmooth = Mathf.Lerp(verticalSmooth, verticalInput, Time.deltaTime * glideSmooth);

        // Bevægelse
        Vector3 move = new Vector3(0, verticalSmooth, 0) * speed * Time.deltaTime;
        transform.position += move;

        // Clamp Y
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        // --- FLY TILT ---
        float targetZRotation = verticalSmooth * tiltAmount;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetZRotation);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * tiltSpeed
        );
    }
}
