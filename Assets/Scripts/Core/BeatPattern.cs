using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBeatPattern", menuName = "Beatclash/Core/Beat Pattern")]
public class BeatPattern : ScriptableObject
{
    public List<NoteType> Notes = new List<NoteType>();
}
