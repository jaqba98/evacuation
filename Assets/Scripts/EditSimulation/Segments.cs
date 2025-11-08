using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Segments : MonoBehaviour {
    public SimulationStore simulationStore;
    public ChooserStore chooserStore;

    public SegmentDomain segmentDomainInstance;
    public GameObject currentChildInstance;

    public void Init() {
        simulationStore.canBuildSegment = true;
        for (int i = transform.childCount - 1; i >= 0; i--) {
            GameObject currentChild = transform.GetChild(i).gameObject;
            DestroyImmediate(currentChild);
        }
        foreach (var segmentDomain in simulationStore.segmentsDomain) {
            if (simulationStore.cursorPositionX == segmentDomain.segmentPositionX && simulationStore.cursorPositionZ == segmentDomain.segmentPositionZ) {
                simulationStore.canBuildSegment = false;
            }
            GameObject prefab = chooserStore.GetSegmentById(segmentDomain.segmentId);
            Vector3 position = new Vector3(segmentDomain.segmentPositionX, 0, segmentDomain.segmentPositionZ);
            Quaternion rotation = Quaternion.Euler(0f, segmentDomain.segmentRotation, 0f);
            GameObject instance = Instantiate(prefab, position, rotation, transform);
            instance.name = segmentDomain.segmentName;
            instance.SetActive(segmentDomain.isVisible);
        }
        List<GameObject> spawnObjectsList = new List<GameObject>();
        List<GameObject> exitObjectsList = new List<GameObject>();
        FindTaggedChildrenRecursive(transform, "Spawn", spawnObjectsList);
        FindTaggedChildrenRecursive(transform, "Exit", exitObjectsList);
        simulationStore.spawns = spawnObjectsList;
        simulationStore.exits = exitObjectsList;
    }

    public void Reload() {
        simulationStore.canBuildSegment = true;
        bool segmentDomainExists = false;
        foreach (SegmentDomain segmentDomain in simulationStore.segmentsDomain) {
            if (segmentDomain.segmentPositionX == simulationStore.cursorPositionX && segmentDomain.segmentPositionZ == simulationStore.cursorPositionZ) {
                segmentDomainExists = true;
                segmentDomainInstance = segmentDomain;
                simulationStore.canBuildSegment = false;
            }
        }
        bool currentChildExists = false;
        for (int i = transform.childCount - 1; i >= 0; i--) {
            GameObject currentChild = transform.GetChild(i).gameObject;
            if (currentChild.transform.position.x == simulationStore.cursorPositionX && currentChild.transform.position.z == simulationStore.cursorPositionZ) {
                currentChildExists = true;
                currentChildInstance = currentChild;
            }
        }
        if (!segmentDomainExists && currentChildExists) {
            DestroyImmediate(currentChildInstance);
        } else if (segmentDomainExists && !currentChildExists) {
            GameObject prefab = chooserStore.GetSegmentById(segmentDomainInstance.segmentId);
            Vector3 position = new Vector3(segmentDomainInstance.segmentPositionX, 0, segmentDomainInstance.segmentPositionZ);
            Quaternion rotation = Quaternion.Euler(0f, segmentDomainInstance.segmentRotation, 0f);
            GameObject instance = Instantiate(prefab, position, rotation, transform);
            instance.name = segmentDomainInstance.segmentName;
            instance.SetActive(segmentDomainInstance.isVisible);
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
