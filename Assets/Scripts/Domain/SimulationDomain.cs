using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SimulationDomain {
    public string simulationName;
    public float cursorPositionX;
    public float cursorPositionZ;
    public float cursorRotation;
    public List<SegmentDomain> segments;
}
