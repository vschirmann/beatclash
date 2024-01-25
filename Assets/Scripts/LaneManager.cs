using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class LaneManager
{
    public const int MIN_LANES = 1;
    public const int MAX_LANES = 4;

    private LaneComponent LanePrefab;
    private Transform LaneContainer;

    // public LaneTemplate Template { get; private set; }
    public Dictionary<UnitType, List<Unit>> TimelineData { get; private set; }
    public Dictionary<int, LaneUnit> LanesConfigurations { get; private set; }

    public int[] InactiveLaneIds { get; private set; }
    public int[] ActiveLaneIds { get; private set; }

    public LaneManager(Timeline timeline, LaneUnit[] lanesConfig)
    {
        TimelineData = new Dictionary<UnitType, List<Unit>>();

        if (timeline != null)
        {
            TimelineData.Add(UnitType.Melody, timeline.MelodyUnits);
            TimelineData.Add(UnitType.Beat, timeline.BeatUnits);
            TimelineData.Add(UnitType.Effect, timeline.EffectUnits);
            TimelineData.Add(UnitType.Vocal, timeline.VocalUnits);
        }

        if (lanesConfig.Any(x => x != LaneUnit.None))
        {
            LanesConfigurations = new Dictionary<int, LaneUnit>();
            LanesConfigurations.AddRange(GetActiveLanesIds(lanesConfig).Select(id => new KeyValuePair<int, LaneUnit>(id, lanesConfig[id - 1])));

            ActiveLaneIds = LanesConfigurations.Select(x => x.Key).ToArray();
            InactiveLaneIds = Enumerable.Range(MIN_LANES, MAX_LANES).Where(x => !ActiveLaneIds.Contains(x)).ToArray();
        }
        else
        {
            Debug.LogError("Lanes not configured");
        }

    }

    public void LoadReferences()
    {
        LanePrefab = Resources.Load<LaneComponent>("Core/Lane");
        LaneContainer = GameObject.FindGameObjectWithTag("LaneContainer")?.transform;
    }

    public void PerformCheckup()
    {
        Debug.Log($"[LaneManager] Lane Prefab : {LanePrefab != null}");
        Debug.Log($"[LaneManager] Lane Container : {LaneContainer != null}");

        Debug.Log("Active Lane Ids : " + string.Join(",", ActiveLaneIds));
        Debug.Log("Inactive Lane Ids : " + string.Join(",", InactiveLaneIds));
        Debug.Log("Active Lanes Config Ids : " + string.Join(",", LanesConfigurations.Keys));
    }

    public void SpawnLanes()
    {

    }

    private int[] GetActiveLanesIds(LaneUnit[] lanesConfigurations)
    {
        return lanesConfigurations.Select((value, index) => new { value, index }).Where(x => x.value != LaneUnit.None).Select(x => x.index + 1).ToArray();
    }

}
