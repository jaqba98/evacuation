using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Delete : MonoBehaviour {
    public SimulationStore simulationStore;
    public Listener listener;
    public EditSimulationMenu editSimulationMenu;

    private void OnEnable() {
        listener.AddAction("l", () => DeleteSegment());
    }

    private void OnDisable() {
        listener.RemoveAction("l");
    }

    public void DeleteSegment() {
        List<SegmentDomain> newSegmentsDomain = new List<SegmentDomain>();
        foreach (var segmentDomain in simulationStore.segmentsDomain) {
            if (simulationStore.cursorPositionX == segmentDomain.segmentPositionX && simulationStore.cursorPositionZ == segmentDomain.segmentPositionZ) {
                continue;
            }
            newSegmentsDomain.Add(segmentDomain);
        }
        simulationStore.segmentsDomain = newSegmentsDomain;
        editSimulationMenu.Reload();
    }
}
