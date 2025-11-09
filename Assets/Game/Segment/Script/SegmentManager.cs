using UnityEngine;
using System.Collections.Generic;

public class SegmentManager : MonoBehaviour {
    public SimulationStore simulationStore;

    [Header("Segments")]
    public List<GameObject> floor = new List<GameObject>();
    public List<GameObject> wall = new List<GameObject>();
    public List<GameObject> corner = new List<GameObject>();
    public List<GameObject> doorOpen = new List<GameObject>();
    public List<GameObject> doorBlock = new List<GameObject>();
    public List<GameObject> doorExit = new List<GameObject>();
    public List<GameObject> spawn = new List<GameObject>();

    public void Init() {
        List<GameObject> segments = new List<GameObject>();
        segments.AddRange(floor);
        segments.AddRange(wall);
        segments.AddRange(corner);
        segments.AddRange(doorOpen);
        segments.AddRange(doorBlock);
        segments.AddRange(doorExit);
        segments.AddRange(spawn);
        simulationStore.segments = segments;
    }

    public GameObject GetSegmentByName(string name) {
        foreach (GameObject segment in simulationStore.segments) {
            if (segment.name == name) {
                return segment;
            }
        }
        throw new System.Exception("Not found segment by name!");
    }
}
