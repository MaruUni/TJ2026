using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Base class for the player
/// <para>Contains references to the player's light and movement interfaces (to keep code separate).</para>
/// <para>The exact class that has the interface should be given on the Inspector, if not, it initializes with a basic one (this could also be done with an enum on inspector and a switch)</para>
/// <para>Configurable attributes are taken from an Scriptable object (PlayerStats). Again because there might be different players, but the skeleton/core should be the same for all.</para>
/// </summary>

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    private IMovement playerMovement;
    private ICombat playerCombat;
    private ILight playerLight;
    void Awake()
    {
        playerMovement = gameObject.GetComponent<IMovement>();
        if (playerMovement == null)
            playerMovement = gameObject.AddComponent<BasicMovement>();

        playerCombat = gameObject.GetComponent<ICombat>();
        if (playerCombat == null)
            playerCombat = gameObject.AddComponent<StunCombat>();

        playerLight = gameObject.GetComponent<ILight>();
        if (playerLight == null)
            playerLight = gameObject.AddComponent<SpotLight>();

        playerMovement.Init(playerStats.Speed);
    }

    #region Player input
    public void Move(InputAction.CallbackContext ctx)
    {
        playerMovement.Move(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y);
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            playerCombat.Attack(1f);
    }

    public void Parry(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            playerCombat.Parry();
    }

    #endregion
}
