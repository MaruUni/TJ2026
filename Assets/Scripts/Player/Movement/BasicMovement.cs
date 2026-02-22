using System.Collections;
using UnityEngine;

public class BasicMovement : MonoBehaviour, IMovement
{
    private float speed;
    private Vector2 moveInput;
    private bool movementDisabled;

    private void FixedUpdate()
    {
        if (!movementDisabled)
            Motion();
    }

    private void Motion()
    {
        // Movement
        Vector3 motionVector = new Vector3(moveInput.x, 0f, moveInput.y);
        float motionMagnitude = motionVector.magnitude;

        // rotate to face the movement direction
        if (motionMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(motionVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);
        }

        // move in the direction of the input
        transform.position += motionVector.normalized * speed * Time.fixedDeltaTime;
    }


    #region IMovement implementation

    void IMovement.Init(float _speed)
    {
        speed = _speed;
    }

    void IMovement.ChangeSpeed(float _speed)
    {
        speed = _speed;
    }

    void IMovement.Move(float horizontal, float vertical)
    {
        moveInput = new Vector2(horizontal, vertical);
    }

    void IMovement.ExecuteAbility(MovementAbilityType abilityType)
    {
        throw new System.NotImplementedException();
    }

    void IMovement.DisableMovement(float duration)
    {
        movementDisabled = true;
        StartCoroutine(EnableMovementAfterDelay(duration));
    }

    IEnumerator EnableMovementAfterDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        movementDisabled = false;
    }
    #endregion
}
