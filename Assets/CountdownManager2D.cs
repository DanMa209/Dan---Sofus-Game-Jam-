
using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownManager2D : MonoBehaviour   // <‑‑ public + : MonoBehaviour
{
    [Header("Refs")]
    public TextMeshProUGUI countdownText;
    public GameObject planeInScene;

    [Header("Timing")]
    public float stepTime = 1f;

    private Rigidbody2D rb;
    private PlaneController2D controller;

    void Start()
    {
        if (!countdownText || !planeInScene)
        {
            Debug.LogError("CountdownManager2D: Mangler reference til countdownText eller planeInScene i Inspector.");
            return;
        }

        rb = planeInScene.GetComponent<Rigidbody2D>();
        controller = planeInScene.GetComponent<PlaneController2D>();

        if (controller) controller.canControl = false;
        if (rb)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
        }

        StartCoroutine(DoCountdown());
    }

    IEnumerator DoCountdown()
    {
        countdownText.gameObject.SetActive(true);

        yield return Step("3");
        yield return Step("2");
        yield return Step("1");
        yield return Step("GO!");

        countdownText.gameObject.SetActive(false);

        if (rb) rb.isKinematic = false;
        if (controller) controller.canControl = true;
    }

    IEnumerator Step(string label)
    {
        countdownText.text = label;
        yield return new WaitForSeconds(stepTime);
    }
}
