
/// <summary>
/// This interface should be implemented by any crystal that can be lit up by the player.
/// </summary>
interface ICrystal
{
    /// <summary>
    /// Light itself with the team color and notify the game manager that the crystal has been lit so it can keep count
    /// </summary>
    void LightUp(int teamIndex);    
}
