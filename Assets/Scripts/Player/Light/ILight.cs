using System.Drawing;

/// <summary>
/// Should be implemented by any light that the player uses (e.g. area light, directional light, etc.)
/// <para>If all lights have a shared functionality, consider making this an abstract class instead of an interface</para>
/// </summary>
interface ILight
{
    /// <summary>
    /// Lights up a crystal (each light type should have a different way of lighting up the crystal, e.g. area light should light up all crystals in a certain radius, point light should light up all crystals in a certain direction, etc.)
    /// </summary>
    void LightCrystal();

    /// <summary>
    /// In case the player has a special ability that depends on the light type
    /// </summary>
    /// <param name="abilityType"></param>
    void ExecuteAbility(LightAbilityType abilityType);
}

