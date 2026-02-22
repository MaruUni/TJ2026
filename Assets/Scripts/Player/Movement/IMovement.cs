using UnityEngine;

/// <summary>
/// To be implemented by any movement type that the player uses.
/// <para>NOTE: Subject to change, i just made it an interface to get a global image to start</para>
/// </summary>
interface IMovement
{
    /// <summary>
    /// Initialize the movement with the given speed. This should be called when the movement is first assigned to the player.
    /// </summary>
    /// <param name="speed"></param>
    void Init(float speed);

    /// <summary>
    /// To change speed during the game
    /// </summary>
    /// <param name="speed"></param>
    void ChangeSpeed(float speed);

    /// <summary>
    /// Primary movement method. Should be called every frame in the player class, and it should move the player according to the given horizontal and vertical input.
    /// </summary>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    void Move(float horizontal, float vertical);

    /// <summary>
    /// For when the player is hit by an attack or something that affects movement, this method should be called with the duration of the effect.
    /// </summary>

    void DisableMovement(float duration);

    /// <summary>
    /// Player abilities related to movement (e.g. dash, teleport...). Should be called when the player uses an ability, and it should execute the ability according to the given type.
    /// </summary>
    /// <param name="abilityType"></param>
    void ExecuteAbility(MovementAbilityType abilityType);
}