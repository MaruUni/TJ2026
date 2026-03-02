using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float Speed = 5f;
    public float DashIncrement = 5.0f;
    //public LightAbilityType LightAbilityType = LightAbilityType.IntensityBoost;
    //public MovementAbilityType MovementAbilityType = MovementAbilityType.Dash;
}
