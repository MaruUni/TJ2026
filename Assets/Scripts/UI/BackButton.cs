using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        AkUnitySoundEngine.PostEvent("Click_UI", gameObject);
        UINavigationManager.Instance.BackToScreen();
    }
}
