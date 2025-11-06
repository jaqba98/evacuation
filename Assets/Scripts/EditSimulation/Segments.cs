using UnityEngine;
using System.Collections.Generic;

public class Segments : MonoBehaviour {
    public SimulationStore simulationStore;
    public ChooserStore chooserStore;

    public void Init() {
        Reload();
    }

    public void Reload() {
        simulationStore.canBuildSegment = true;
        for (int i = transform.childCount - 1; i >= 0; i--) {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
        foreach (var segmentDomain in simulationStore.segmentsDomain) {
            GameObject prefab = chooserStore.GetSegmentById(segmentDomain.segmentId);
            Vector3 position = new Vector3(segmentDomain.segmentPositionX, 0, segmentDomain.segmentPositionZ);
            Quaternion rotation = Quaternion.Euler(0f, segmentDomain.segmentRotation, 0f);
            GameObject instance = Instantiate(prefab, position, rotation, transform);
            instance.name = segmentDomain.segmentName;
            instance.SetActive(segmentDomain.isVisible);
            if (simulationStore.cursorPositionX == segmentDomain.segmentPositionX && simulationStore.cursorPositionZ == segmentDomain.segmentPositionZ) {
                simulationStore.canBuildSegment = false;
            }
        }
        List<GameObject> spawnObjectsList = new List<GameObject>();
        List<GameObject> exitObjectsList = new List<GameObject>();
        FindTaggedChildrenRecursive(transform, "Spawn", spawnObjectsList);
        FindTaggedChildrenRecursive(transform, "Exit", exitObjectsList);
        simulationStore.spawns = spawnObjectsList;
        simulationStore.exits = exitObjectsList;
    }

    private void FindTaggedChildrenRecursive(Transform parent, string tag, List<GameObject> list) {
        foreach (Transform child in parent) {
            if (child.CompareTag(tag)) {
                list.Add(child.gameObject);
            }
            if (child.childCount > 0) {
                FindTaggedChildrenRecursive(child, tag, list);
            }
        }
    }
}
