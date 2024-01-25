using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTimeline", menuName = "Beatclash/Core/Timeline")]
public class Timeline : ScriptableObject
{
    public int TargetBPM = 120;
    public List<Unit> BeatUnits = new List<Unit>();
    public List<Unit> MelodyUnits = new List<Unit>();
    public List<Unit> EffectUnits = new List<Unit>();
    public List<Unit> VocalUnits = new List<Unit>();
}
