using UnityEngine;
using UnityEngine.UI;

public class OxygenSystem : MonoBehaviour
{
    public Slider oxygenBar;
    public float oxygen = 100f;
    public float maxOxygen = 100f;

    public float highAltitudeY = 3f;   // hvor højt man må flyve før man mister oxygen
    public float oxygenDrain = 10f;    // oxygen per sekund når man er for højt

    public Image fillImage;            // Træk Fill (den farvede del) ind her

    void Update()
    {
        // Hvis spilleren er for højt oppe
        if (transform.position.y > highAltitudeY)
        {
            oxygen -= oxygenDrain * Time.deltaTime;
        }

        // Oxygen må ikke gå under 0
        oxygen = Mathf.Clamp(oxygen, 0, maxOxygen);

        // Opdater UI
        if (oxygenBar != null)
        {
            oxygenBar.value = oxygen;
        }

        // BLINK RØD NÅR MAN MISTER OXYGEN
        if (fillImage != null)
        {
            if (oxygen < maxOxygen) // så snart man har mistet noget oxygen
            {
                float blink = Mathf.Abs(Mathf.Sin(Time.time * 5)); // 5 = hvor hurtigt den blinker
                Color c = Color.red;
                c.a = blink;          // alpha blinker
                fillImage.color = c;
            }
            else
            {
                // Fuldt oxygen = normal (hvid) og ikke blink
                fillImage.color = Color.white;
            }
        }

        // Hvis oxygen = 0 → død
        if (oxygen <= 0)
        {
            FindObjectOfType<deathCollision>().SendMessage("Die");
        }
    }
}
