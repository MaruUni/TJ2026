using System.Collections;
using UnityEngine;

public class StunCombat : MonoBehaviour, ICombat
{
    private bool isProtected;
    private float stunDuration = 2f;

    #region ICombat implementation
    public void Attack(float? attackRadius = null)
    {
        Debug.Log("Stun attack executed!");
        Collider[] collisions = Physics.OverlapSphere(transform.position, attackRadius.Value);

        foreach (Collider collider in collisions)
        {
            StunCombat enemy = collider.gameObject.GetComponentInParent<StunCombat>();
            if (enemy != null && enemy != this)
            {
                Debug.Log("Stun attack is hitting!");
                enemy.GetHit(stunDuration);
            }
        }
    }

    public void GetHit(float? attackEffect = null)
    {
        if (!isProtected)
        {
            Debug.Log("Player got hit and is unprotected");
            IMovement movement = GetComponent<IMovement>();
            StartCoroutine(movement.DisableMovement(attackEffect.Value));
        }
        else
        {
            Debug.Log("Player got hit but is protected");
        }
    }

    public void Parry()
    {
        // TODO: this just protects player for a short time but it should be more complex
        Debug.Log("Parry executed! Player is protected for a short time.");
        isProtected = true;
        StartCoroutine(EndParry());
    }
    #endregion

    #region Extra methods for the stun combat    

    IEnumerator EndParry()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Parry over! Player unprotected.");
        isProtected = false;
    }

    #endregion


}
