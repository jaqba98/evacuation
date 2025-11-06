using UnityEngine;
using System.Collections.Generic;

public class ChooserStore : MonoBehaviour {
    public List<GameObject> segmentsPrefab;

    public GameObject GetSegmentById(int segmentId) {
        return segmentsPrefab[segmentId];
    }
}
