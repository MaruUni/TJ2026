using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Button))]
public class BaseButton : MonoBehaviour
{
    protected ScreenManager screenManager;
    protected Button button;

    protected virtual void Awake()
    {
        screenManager = GetComponentInParent<ScreenManager>();
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }

    protected virtual void OnClick()
    {
        throw new System.NotImplementedException("Implement method on child object.");
    }
}
