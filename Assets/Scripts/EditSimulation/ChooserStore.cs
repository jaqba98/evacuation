using UnityEngine;
using System.Collections.Generic;

public class ChooserStore : MonoBehaviour {
    public SegmentManager segmentManager;

    public List<GameObject> segmentsPrefab;

    public void Awake() {
        segmentsPrefab = segmentManager.GetSegments();
    }

    public GameObject GetSegmentById(int segmentId) {
        return segmentsPrefab[segmentId];
    }
}
