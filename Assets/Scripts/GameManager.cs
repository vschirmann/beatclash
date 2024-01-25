using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// public enum LaneTemplate { Two, Four };
// public static class LaneTemplateExtensions
// {
//     public static int ToInt(this LaneTemplate lt) { return lt == LaneTemplate.Two ? 2 : 4; }
// }

public class GameManager : MonoBehaviour
{
    public static GameManager Reference;

    [Header("References")]
    public PlayerController PlayerController;
    public Transform ButtonsContainer;
    private LaneManager _laneManager;

    [Header("Settings")]
    public Timeline TimelineToPlay;

    [Header("Lanes Configuration")]
    public LaneUnit Lane1Configuration;
    public LaneUnit Lane2Configuration;
    public LaneUnit Lane3Configuration;
    public LaneUnit Lane4Configuration;

    #region Properties
    public LaneComponent[] Lanes { get; private set; }
    #endregion

    void Awake()
    {
        if (GameManager.Reference != null)
        {
            Destroy(gameObject);
        }

        GameManager.Reference = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _laneManager = new LaneManager(TimelineToPlay, new[] { Lane1Configuration, Lane2Configuration, Lane3Configuration, Lane4Configuration });
        _laneManager.LoadReferences();
        _laneManager.PerformCheckup();

        // Debug.Log("Active Lanes : " + String.Join(",", _laneManager.ActiveLaneIds));
        // Debug.Log("Inactive Lanes : " + String.Join(",", _laneManager.InactiveLaneIds));

        // InitializeLanes();
    }

    void InitializeLanes()
    {
        // Debug.Log("Hello");
        // Lanes = new LaneComponent[LaneCount.ToInt()];

        // for (int i = 0; i < LaneCount.ToInt(); i++)
        // {
        //     var lane = Instantiate(LanePrefab, LaneContainer);
        //     lane.Initialize(i + 1);

        //     Lanes[i] = lane;
        // }

        // if (LaneCount == LaneTemplate.Two)
        // {
        //     ButtonsContainer.Find("HitButton_Lane_3")?.gameObject.SetActive(false);
        //     ButtonsContainer.Find("HitButton_Lane_4")?.gameObject.SetActive(false);
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
}