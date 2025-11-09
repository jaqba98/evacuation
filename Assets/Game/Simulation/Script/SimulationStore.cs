using UnityEngine;
using System.Collections.Generic;

public class SimulationStore : MonoBehaviour {
    public float segmentSize;
    public Vector3 cursorPosition;
    public Vector3 cursorRotation;
    public List<GameObject> segments;
    public int currentSegmentIndex;
    public GameObject currentSegment;
    public List<SegmentDomain> segmentDomains;
    public string path;
    public int cameraSize;
    public bool canBuildSegment;
    public int maxCursorPositionLeft;
    public int maxCursorPositionRight;
    public int maxCursorPositionUp;
    public int maxCursorPositionDown;
}
