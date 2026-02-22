using UnityEngine;

/// <summary>
/// Global place to set the game rules and stats. 
/// <para>Most useful if multiple GameStats settings exist on the game. It should be given on the Inspector of the Game Manager (or Level Manager if we have one)</para>
/// <para>This can: be easily accessed by the game designer from the editor, be used for multiple scenes, be modified on runtime by other scripts</para>
/// <para>NOTE: Attributes subject to change, Im just building a skeleton of what could the use of this Scriptable Object be</para>
/// </summary>

[CreateAssetMenu(fileName = "GameStats", menuName = "Scriptable Objects/GameStats")]
public class GameStats : ScriptableObject
{
    public int MaxScore = 5; // if a team reaches this score, the game ends
    public float Duration = 120f; // if the time runs out, the team with the highest score wins. If it's a tie, the game goes to sudden death
    public Color[] teamColors = new Color[2]; // team colors, to be used for the crystals and the player lights. The index of the color should correspond to the team index (e.g. teamColors[0] is the color for team 0)

}
