using UnityEngine;
public class PopupShowButton : BaseButton
{
    [SerializeField] GameObject popupScreen;


    /// <summary>
    /// Important that this executes on Awake because we need to make sure the popup is hidden when the scene starts.
    /// If this button is (as it should) part of an IScreen, it will be enabled on Awake for initialization and then disabled on Start (if its not part of the first shown IScreen)
    /// </summary>
    override protected void Awake()
    {
        base.Awake();

        if (popupScreen == null)
        {
            Debug.LogError("PopupShowButton: popupScreen is not assigned in the inspector.");
        }
        else
        {
            popupScreen.SetActive(false); // Ensure the popup is hidden at the start
        }
    }

    override protected void OnClick()
    {
        popupScreen.SetActive(true);
    }
}