using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Needed for URP Decals

public class BloodSplatter: MonoBehaviour
{
    [Header("Settings")]
    public float stayDuration = 3f; // How long the blood stays solid
    public float fadeDuration = 2f; // How long it takes to fade away

    private DecalProjector decal;

    void Start()
    {
        // Find the decal projector in the child object
        decal = GetComponentInChildren<DecalProjector>();

        if (decal != null)
        {
            // Start the fading process
            StartCoroutine(FadeAndDestroy());
        }
        else
        {
            // If no decal is found, just destroy the object after the time is up
            Destroy(gameObject, stayDuration + fadeDuration);
        }
    }

    private IEnumerator FadeAndDestroy()
    {
        // 1. Wait for the 'stay' duration while the blood is fully visible
        yield return new WaitForSeconds(stayDuration);

        // 2. Gradually fade the decal
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            // fadeFactor is a built-in URP Decal property (1 is solid, 0 is invisible)
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            decal.fadeFactor = alpha;

            yield return null; // Wait for the next frame
        }

        // 3. Ensure it is completely invisible, then destroy the GameObject
        decal.fadeFactor = 0f;
        Destroy(gameObject);
    }
}