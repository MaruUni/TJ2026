using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DiaryEntry : MonoBehaviour
{
    [SerializeField] TextField entryTitle;
    [SerializeField] TextField entryText;
    DiaryManager diaryManager;

    int diaryEntryIdx;
    ParticleSystem newReadVFX;
    bool goneTrough = false;

    void Awake()
    {
        newReadVFX = GetComponent<ParticleSystem>();

        // start disabled
        gameObject.SetActive(false);
    }

    public void Initialize(DiaryManager diaryManager, bool goneTrough, int idx)
    {
        this.diaryManager = diaryManager;
        gameObject.SetActive(true);
        this.goneTrough = goneTrough;
        diaryEntryIdx = idx;

        if (goneTrough)
            newReadVFX.Play();
    }


    public void ReadDiary()
    {
        diaryManager.EntryTitleSlot.text = entryTitle.text;
        diaryManager.EntryTextSlot.text = entryText.text;
        UINavigationManager.Instance.ShowScreen(ScreenName.DiaryEntry, false);

        if (!goneTrough)
        {
            goneTrough = true;
            newReadVFX.Stop();
            SystemGameDataStorage.Instance.GoThroughDiaryEntry(diaryEntryIdx);
        }
    }


}
