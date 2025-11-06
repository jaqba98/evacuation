using UnityEngine;
using System.Collections.Generic;
using System;

public class Chooser : MonoBehaviour {
    public SimulationStore simulationStore;
    public Listener listener;
    public EditSimulationMenu editSimulationMenu;
    public ChooserStore chooserStore;

    public void Reload() {
        if (chooserStore.segmentsPrefab.Count == 0) {
            throw new Exception("There segmentsPrefab list is empty!");
            return;
        }
        Reset();
        chooserStore.segmentsPrefab[simulationStore.currentSegment].SetActive(true);
        simulationStore.currentSegmentPrefab = chooserStore.segmentsPrefab[simulationStore.currentSegment];
    }

    private void OnEnable() {
        listener.AddAction("i", () => ChangeSegment(-1));
        listener.AddAction("p", () => ChangeSegment(1));
    }

    private void OnDisable() {
        listener.RemoveAction("i");
        listener.RemoveAction("p");
    }

    private void ChangeSegment(int direction) {
        if (simulationStore.frozen) return;
        if (chooserStore.segmentsPrefab.Count == 0) {
            throw new Exception("There segmentsPrefab list is empty!");
            return;
        }
        simulationStore.currentSegment += direction;
        if (simulationStore.currentSegment >= chooserStore.segmentsPrefab.Count) {
            simulationStore.currentSegment = 0;
        }
        if (simulationStore.currentSegment < 0) {
            simulationStore.currentSegment = chooserStore.segmentsPrefab.Count - 1;
        }
        editSimulationMenu.Reload();
    }

    public void Reset() {
        foreach (var segmentPrefab in chooserStore.segmentsPrefab) {
            segmentPrefab.SetActive(false);
        }
    }
}
