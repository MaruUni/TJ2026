using UnityEngine;

public class PopupHideButton : BaseButton
{
    [SerializeField] GameObject popupScreen;

    override protected void OnClick()
    {
        popupScreen.SetActive(false);
    }
}