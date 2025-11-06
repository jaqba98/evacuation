using UnityEngine;

public class Create : MonoBehaviour {
    public SimulationStore simulationStore;
    public Listener listener;
    public EditSimulationMenu editSimulationMenu;

    private void OnEnable() {
        listener.AddAction("o", () => CreateSegment());
    }

    private void OnDisable() {
        listener.RemoveAction("o");
    }

    public void CreateSegment() {
        if (!simulationStore.canBuildSegment) return;
        SegmentDomain newSegmentDomain = new SegmentDomain();
        newSegmentDomain.segmentName = simulationStore.currentSegmentPrefab.name;
        newSegmentDomain.segmentPositionX = simulationStore.cursorPositionX;
        newSegmentDomain.segmentPositionZ = simulationStore.cursorPositionZ;
        newSegmentDomain.segmentRotation = simulationStore.cursorRotation;
        newSegmentDomain.isVisible = true;
        newSegmentDomain.segmentId = simulationStore.currentSegment;
        simulationStore.segmentsDomain.Add(newSegmentDomain);
        editSimulationMenu.Reload();
    }
}
