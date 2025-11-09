using UnityEngine;
using System.Collections.Generic;

public class Create : MonoBehaviour {
    public SimulationStore simulationStore;
    public EditSimulation editSimulation;
    public Listener listener;

    public void Init() {
        simulationStore.segmentDomains = new List<SegmentDomain>();
    }

    private void OnEnable() {
        listener.AddAction("o", () => CreateSegment());
    }

    private void OnDisable() {
        listener.RemoveAction("o");
    }

    public void CreateSegment() {
        GameObject currentSegment = simulationStore.currentSegment;
        SegmentDomain newSegmentDomain = new SegmentDomain();
        newSegmentDomain.name = currentSegment.name;
        newSegmentDomain.position = simulationStore.cursorPosition;
        newSegmentDomain.rotation = simulationStore.cursorRotation;
        simulationStore.segmentDomains.Add(newSegmentDomain);
        editSimulation.Reload();
    }
}
