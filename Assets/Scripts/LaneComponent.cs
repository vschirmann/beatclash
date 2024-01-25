using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaneComponent : MonoBehaviour
{
    static readonly Color32[] LANE_COLORS = {
        new Color32(0x3C, 0xDB, 0x4E, 0x7F), // GREEN
        new Color32(0xd0, 0x42, 0x42, 0x7F), // RED
        new Color32(0x40, 0xcc, 0xd0, 0x7F), // BLUE,
        new Color32(0xec, 0xdb, 0x33, 0x7F) // YELLOW
    };

    public NoteComponent NotePrefab;

    private RectTransform _laneRect;
    private RectTransform _spawnPoint;
    private RectTransform _hitZone;
    private RectTransform _missPoint;
    private RectTransform _noteContainer;
    private Queue<NoteComponent> _noteQueue;

    public int Id { get; private set; }

    public void Initialize(int laneId)
    {
        Id = laneId;
        transform.name = $"Lane_{Id}";

        _laneRect = GetComponent<RectTransform>();
        _spawnPoint = transform.Find("SpawnPoint")?.GetComponent<RectTransform>();
        _hitZone = transform.Find("HitZone")?.GetComponent<RectTransform>();
        _missPoint = transform.Find("MissPoint")?.GetComponent<RectTransform>();
        _noteContainer = transform.Find("NoteContainer")?.GetComponent<RectTransform>();

        // TODO: Replace with fail safe behavior
        if (_spawnPoint == null) Debug.LogError($"[{transform.name}] Spawn Point not found");
        if (_hitZone == null) Debug.LogError($"[{transform.name}] Hit Zone not found");
        if (_missPoint == null) Debug.LogError($"[{transform.name}] Miss Point not found");

        // Setup Color
        _hitZone.GetComponent<Image>().color = LANE_COLORS[Id - 1];

        PositionLaneOnScreen();
    }

    void PositionLaneOnScreen()
    {
        switch (Id)
        {
            case 1:
                _laneRect.anchoredPosition = new Vector2(-75f, 0f);
                break;
            case 2:
                _laneRect.anchoredPosition = new Vector2(75f, 0f);
                break;
            case 3:
                _laneRect.anchoredPosition = new Vector2(-200f, 0f);
                break;
            case 4:
                _laneRect.anchoredPosition = new Vector2(200f, 0f);
                break;
            default: break;
        }
    }

    void SpawnNote()
    {
        var note = Instantiate(NotePrefab, _spawnPoint.position, Quaternion.identity, _noteContainer);

        Debug.Log("Tap Note : " + note.GetType().Equals(typeof(TapNoteComponent)));
        Debug.Log("Hold Note : " + note.GetType().Equals(typeof(HoldNoteComponent)));
    }

    void Start()
    {
        // TEMP
        // _noteContainer = transform.Find("NoteContainer")?.GetComponent<RectTransform>();
        // _spawnPoint = transform.Find("SpawnPoint")?.GetComponent<RectTransform>();

        // SpawnNote();
    }
}
