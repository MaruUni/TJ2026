using UnityEngine;
using UnityEngine.EventSystems;

public class Starman : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Audio
        MusicManager.Instance.PlayStarmanMusic();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Audio
        MusicManager.Instance.PlayTitleMusic();
    }

    public void OnSelect(BaseEventData eventData)
    {
        //Audio
        MusicManager.Instance.PlayStarmanMusic();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //Audio
        MusicManager.Instance.PlayTitleMusic();
    }
}
