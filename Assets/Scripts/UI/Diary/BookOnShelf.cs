using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// Physical book on shelf, that has a reference to the idx of the text
/// </summary>
public class BookOnShelf : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, ISelectHandler, ISubmitHandler
{
    BookshelfManager bookshelfManager;

    int entryIdx;
    GameObject newReadVFX;
    bool goneTrough = false;

    void Awake()
    {
        newReadVFX = GetComponentInChildren<Animator>().gameObject;

        // start disabled
        gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Audio
        AkUnitySoundEngine.PostEvent("Book_Move", gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Audio
        AkUnitySoundEngine.PostEvent("Book_Open", gameObject);
    }

    public void OnSelect(BaseEventData eventData)
    {
        //Audio
        AkUnitySoundEngine.PostEvent("Book_Move", gameObject);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        //Audio
        AkUnitySoundEngine.PostEvent("Book_Open", gameObject);
    }
    public void Initialize(BookshelfManager bookshelfManager, bool goneTrough, int entryIdx)
    {
        this.bookshelfManager = bookshelfManager;
        gameObject.SetActive(true);
        this.goneTrough = goneTrough;
        newReadVFX.SetActive(!goneTrough);
        this.entryIdx = entryIdx;
    }

    public void ReadDiary()
    {
        bookshelfManager.ChangeEntryText(entryIdx);

        UINavigationManager.Instance.ShowScreen(ScreenName.DiaryEntry, false);

        if (!goneTrough)
        {
            goneTrough = true;
            newReadVFX.SetActive(!goneTrough);
            SystemGameDataStorage.Instance.GoThroughDiaryEntry(entryIdx);
        }
    }
}
