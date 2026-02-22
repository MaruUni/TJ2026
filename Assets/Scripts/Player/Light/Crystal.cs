using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class Crystal : MonoBehaviour, ICrystal
{
    private Light crystalLight;
    private void Awake()
    {
        crystalLight = GetComponent<Light>();
        crystalLight.enabled = false;
    }

    public void LightUp(int teamIndex)
    {
        if (crystalLight.enabled) return; // Prevent multiple scoring from the same crystal
        crystalLight.color = GameManager.Instance.GetTeamColor(teamIndex);
        GameManager.Instance.AddToScore(teamIndex);
        crystalLight.enabled = true;

        StartCoroutine(Unlit());
    }

    IEnumerator Unlit()
    {
        yield return new WaitForSeconds(5f);
        crystalLight.enabled = false;
    }
}
