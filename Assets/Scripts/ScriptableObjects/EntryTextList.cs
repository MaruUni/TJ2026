using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntryTextList", menuName = "Scriptable Objects/EntryTextList")]
public class EntryTextList : ScriptableObject
{
    public List<EntryText> entries;
}