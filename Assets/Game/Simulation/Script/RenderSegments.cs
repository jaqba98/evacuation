using UnityEngine;
using System.Collections.Generic;

public class RenderSegments : MonoBehaviour {
    public SimulationStore simulationStore;
    public SegmentManager segmentManager;

    public void Reload() {
        for (int i = transform.childCount - 1; i >= 0; i--) {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
        foreach (SegmentDomain segmentDomain in simulationStore.segmentDomains) {
            string name = segmentDomain.name;
            GameObject segmentPrefab = segmentManager.GetSegmentByName(name);
            Quaternion rotation = Quaternion.Euler(segmentDomain.rotation);
            GameObject instance = Instantiate(segmentPrefab, segmentDomain.position, rotation, transform);
        }
    }
}