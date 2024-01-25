using System;

public enum NoteType { Empty, Tap, Hold }

public enum UnitType { Melody, Beat, Effect, Vocal }

[Flags]
public enum LaneUnit { None = 0, Melody = 1 << 0, Beat = 1 << 1, Effect = 1 << 2, Vocal = 1 << 3 };