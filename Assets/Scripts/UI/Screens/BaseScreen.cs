using UnityEngine;

public class BaseScreen : MonoBehaviour, IScreen
{
    [SerializeField] protected ScreenName _name;

    public string GetName()
    {
        return _name.ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
