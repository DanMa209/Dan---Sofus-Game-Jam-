using UnityEngine;

public class ShipPotion : MonoBehaviour
{
    private bool effectActive = false;     // Kan kun tage én potion ad gangen
    private float effectDuration = 5f;     // Hvor længe effekten varer
    private Vector3 originalScale;         // Gemmer normal størrelse

    void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (effectActive) return; // Ignorer hvis en effekt allerede kører

        if (other.CompareTag("PotionGrow"))
        {
            StartCoroutine(GrowEffect());
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("PotionShrink"))
        {
            StartCoroutine(ShrinkEffect());
            Destroy(other.gameObject);
        }
    }

    private System.Collections.IEnumerator GrowEffect()
    {
        effectActive = true;
        transform.localScale = originalScale * 1.3f;

        yield return new WaitForSeconds(effectDuration);

        transform.localScale = originalScale;
        effectActive = false;
    }

    private System.Collections.IEnumerator ShrinkEffect()
    {
        effectActive = true;
        transform.localScale = originalScale * 0.7f;

        yield return new WaitForSeconds(effectDuration);

        transform.localScale = originalScale;
        effectActive = false;
    }
}
