using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{
    List<DiaryEntry> allDiaries;

    // references to the entry text visualizer
    TextMeshPro entryTitleSlot;
    public TextMeshPro EntryTitleSlot => entryTitleSlot;

    TextMeshPro entryTextSlot;
    public TextMeshPro EntryTextSlot => entryTextSlot;

    private void Awake()
    {
        GetComponentsInChildren<DiaryEntry>(true, allDiaries); // the order is always the same

        TextMeshPro[] texts = GetComponentsInChildren<TextMeshPro>(true);
        foreach (TextMeshPro text in texts)
        {
            if (text.gameObject.CompareTag("EntryTitle"))
                entryTitleSlot = text;
            else if (text.gameObject.CompareTag("EntryText"))
                entryTextSlot = text;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // enable unlocked entries, and set vfx active if unread
        List<int> unlockedEntries = SystemGameDataStorage.Instance.GetUnlockedDiaryEntries();
        List<int> goneThroughEntries = SystemGameDataStorage.Instance.GetGoneThroughDiaryEntries();

        foreach (int idx in unlockedEntries)
        {
            allDiaries[idx].Initialize(this, goneThroughEntries.Contains(idx), idx);
        }
    }
}
