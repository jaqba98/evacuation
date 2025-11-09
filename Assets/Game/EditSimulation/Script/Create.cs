using UnityEngine;
using System.Collections.Generic;

public class Create : MonoBehaviour {
    public SimulationStore simulationStore;
    public EditSimulation editSimulation;
    public Listener listener;
    public DomainManager domainManager;

    public void Init() {
        simulationStore.segmentDomains = domainManager.simulationDomain.segments;
    }

    private void OnEnable() {
        listener.AddAction("o", () => CreateSegment());
    }

    private void OnDisable() {
        listener.RemoveAction("o");
    }

    public void CreateSegment() {
        if (!simulationStore.canBuildSegment) return;
        GameObject currentSegment = simulationStore.currentSegment;
        SegmentDomain newSegmentDomain = new SegmentDomain();
        newSegmentDomain.name = currentSegment.name;
        newSegmentDomain.position = simulationStore.cursorPosition;
        newSegmentDomain.rotation = simulationStore.cursorRotation;
        simulationStore.segmentDomains.Add(newSegmentDomain);
        editSimulation.Reload();
    }
}
