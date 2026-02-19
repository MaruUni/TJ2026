using UnityEngine;
public class ExitGameButton : BaseButton
{
    [SerializeField] GameObject popupScreen;

    override protected void OnClick()
    {
        Application.Quit();
    }
}
