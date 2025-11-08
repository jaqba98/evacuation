using UnityEngine;
using System.Collections.Generic;

public class SegmentManager : MonoBehaviour {
    public List<GameObject> floor = new List<GameObject>();
    public List<GameObject> wall = new List<GameObject>();
    public List<GameObject> corner = new List<GameObject>();
    public List<GameObject> doorOpen = new List<GameObject>();
    public List<GameObject> doorBlock = new List<GameObject>();
    public List<GameObject> doorExit = new List<GameObject>();
    public List<GameObject> spawn = new List<GameObject>();

    public List<GameObject> GetSegments() {
        List<GameObject> segments = new List<GameObject>();
        segments.AddRange(floor);
        segments.AddRange(wall);
        segments.AddRange(corner);
        segments.AddRange(doorOpen);
        segments.AddRange(doorBlock);
        segments.AddRange(doorExit);
        segments.AddRange(spawn);
        return segments;
    }
}
