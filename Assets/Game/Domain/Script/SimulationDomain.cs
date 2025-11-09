using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SimulationDomain {
    public string path;
    public Vector3 cursorPosition;
    public Vector3 cursorRotation;
    public List<SegmentDomain> segments;
    public int currentSegmentIndex;
    public int cameraSize;

    public SimulationDomain(
        string path,
        Vector3 cursorPosition,
        Vector3 cursorRotation,
        List<SegmentDomain> segments,
        int currentSegmentIndex,
        int cameraSize
    ) {
        this.path = path;
        this.cursorPosition = cursorPosition;
        this.cursorRotation = cursorRotation;
        this.segments = segments;
        this.currentSegmentIndex = currentSegmentIndex;
        this.cameraSize = cameraSize;
    }
}
