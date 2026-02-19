using UnityEngine;
public class SwitchScreenButton : BaseButton
{
    [SerializeField] ScreenName nextScreenName;

    override protected void OnClick()
    {
        screenManager.SwitchScreen(nextScreenName.ToString());
    }
}