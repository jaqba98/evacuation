using UnityEngine;

public class Chooser : MonoBehaviour {
    public SimulationStore simulationStore;
    public EditSimulation editSimulation;
    public ListenerTool listenerTool;
    public DomainManager domainManager;

    public void Init() {
        simulationStore.currentSegmentIndex = domainManager.simulationDomain.currentSegmentIndex;
    }

    public void Reload() {
        for (int i = transform.childCount - 1; i >= 0; i--) {
            Destroy(transform.GetChild(i).gameObject);
        }
        simulationStore.currentSegment = simulationStore.segments[simulationStore.currentSegmentIndex];
        GameObject currentSegment = simulationStore.currentSegment;
        GameObject newSegment = Instantiate(currentSegment, transform);
        newSegment.transform.SetParent(transform);
        newSegment.transform.localPosition = Vector3.zero;
        newSegment.transform.localRotation = Quaternion.identity;
        newSegment.transform.localScale = Vector3.one;
    }

    private void OnEnable() {
        listenerTool.AddAction("i", () => ChangeSegment(-1));
        listenerTool.AddAction("p", () => ChangeSegment(1));
    }

    private void OnDisable() {
        listenerTool.RemoveAction("i");
        listenerTool.RemoveAction("p");
    }

    private void ChangeSegment(int direction) {
        simulationStore.currentSegmentIndex += direction;
        if (simulationStore.currentSegmentIndex >= simulationStore.segments.Count) {
            simulationStore.currentSegmentIndex = 0;
        }
        if (simulationStore.currentSegmentIndex < 0) {
            simulationStore.currentSegmentIndex = simulationStore.segments.Count - 1;
        }
        editSimulation.Reload();
    }
}
