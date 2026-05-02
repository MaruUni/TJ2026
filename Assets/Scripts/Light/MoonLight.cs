using Unity.Mathematics;
using UnityEngine;

public class MoonLight : MonoBehaviour
{
    #region variables
    [Header("Moon Light Settings")]
    [SerializeField] float startAngle;
    [SerializeField] float endAngle;

    private float passedSteps = 0;
    private float maxSteps = 0;
    private bool timeBelowZero = false;
    #endregion

    void Start()
    {
        transform.rotation = Quaternion.Euler(startAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        maxSteps = Mathf.Ceil(GameStatsAccess.Instance.GetGameDuration() / Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        if(timeBelowZero) return;

        UpdateSteps();
        UpdateAngle();
    }
    
    private void UpdateSteps()
    {
        passedSteps += 1;

        float remainingTime = (maxSteps * Time.fixedDeltaTime) - (passedSteps * Time.fixedDeltaTime);

        if (remainingTime <= 0)
        {
            timeBelowZero = true;
        }

    }

    private void UpdateAngle()
    {
        float epsilon = Mathf.Abs(endAngle - startAngle) / maxSteps;
        gameObject.transform.Rotate(Vector3.right, epsilon);
    }

}
