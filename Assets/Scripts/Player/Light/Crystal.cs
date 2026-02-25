using System.Collections;
using UnityEngine;

/// <summary>
/// Crystal class, attached to the crystal game objects. 
/// <para>It is responsible for managing its own emission and the call to GameManager to score changes when it is lit up by a player's light.</para>
/// </summary>
[RequireComponent(typeof(Light))]
public class Crystal : MonoBehaviour
{
    private Light crystalLight;
    private bool isLit = false;
    private int lastTeamIndex = -1;
    private bool cooldownActive = false;

    private void Awake()
    {
        crystalLight = GetComponent<Light>();
        crystalLight.enabled = false;
    }

    public void LightUp(int teamIndex)
    {
        if (cooldownActive) return; // Prevent multiple scoring while the crystal has just been lit

        if (teamIndex == lastTeamIndex) return; // Prevent scoring if the same team tries to light the crystal again

        if (isLit) // A different team is trying to light the crystal, add to their score and subtract from the previous team score
        {
            TurnLightOn(teamIndex);
            GameManager.Instance.ChangeScore(teamIndex, 1);
            GameManager.Instance.ChangeScore(lastTeamIndex, -1);
        }
        else // Crystal lit for the first time, just add to the team's score
        {
            TurnLightOn(teamIndex);
            GameManager.Instance.ChangeScore(teamIndex, 1);
        }

        isLit = true;
        lastTeamIndex = teamIndex;
        cooldownActive = true;
        StartCoroutine(TurnLightOff());
    }

    void TurnLightOn(int teamIndex)
    {
        crystalLight.color = GameManager.Instance.GetTeamColor(teamIndex);
        crystalLight.enabled = true;
        crystalLight.intensity = GameManager.Instance.GetCrystalIntensityWhileCooling(); // You can adjust this value or make it a serialized field if you want different intensity for different crystals
    }

    IEnumerator TurnLightOff()
    {
        yield return new WaitForSeconds(GameManager.Instance.GetCrystalCooldownTime());
        crystalLight.intensity = GameManager.Instance.GetCrystalIntensityWhilePicked();
        cooldownActive = false;
    }
}
