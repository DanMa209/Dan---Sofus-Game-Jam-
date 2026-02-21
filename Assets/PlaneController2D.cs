
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlaneController2D : MonoBehaviour
{
    [Header("Control")]
    public bool canControl = false; // bliver sat til true når countdown er færdig
    public float thrust = 8f;
    public float maxSpeed = 12f;
    public float pitchTorque = 5f;

    [Header("Auto")]
    public float autoLevelStrength = 1.5f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.4f; // justér efter smag
    }

    void Update()
    {
        if (!canControl) return;

        // W/S eller piletaster op/ned
        float v = Input.GetAxisRaw("Vertical");
        rb.AddTorque(-v * pitchTorque * Time.deltaTime, ForceMode2D.Force);

        // Lidt auto-level når der ikke styres
        if (Mathf.Abs(v) < 0.1f)
        {
            float diff = Mathf.DeltaAngle(rb.rotation, 0f);
            rb.AddTorque(diff * autoLevelStrength * Time.deltaTime, ForceMode2D.Force);
        }
    }

    void FixedUpdate()
    {
        // Fremad “thrust” i flyets retning (sprite peger normalt mod højre)
        rb.AddForce(transform.right * thrust, ForceMode2D.Force);

        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
    }
}
