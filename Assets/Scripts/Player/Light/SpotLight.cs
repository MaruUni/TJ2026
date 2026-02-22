using UnityEngine;

public class SpotLight : MonoBehaviour, ILight
{
    int teamIndex;
    private void Awake()
    {
        if (gameObject.CompareTag("Player1"))
        {
            teamIndex = 0;
        }
        else if (gameObject.CompareTag("Player2"))
        {
            teamIndex = 1;
        }
    }

    private void FixedUpdate()
    {
        LightCrystal();
    }

    public void LightCrystal()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 5f))
        {
            Debug.Log(hit.transform.name);
            ICrystal crystal = hit.transform.GetComponent<ICrystal>();
            if (crystal != null)
            {
                Debug.Log("I HIT A CRYSTAL " + teamIndex);
                crystal.LightUp(teamIndex);
            }
        }
    }
    public void ExecuteAbility(LightAbilityType abilityType)
    {
        throw new System.NotImplementedException();
    }
}
