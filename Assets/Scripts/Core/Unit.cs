using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUnit", menuName = "Beatclash/Core/Unit")]
public class Unit : ScriptableObject
{
    public UnitType UnitType;
    public BeatPattern BeatPattern;
}
