using UnityEngine;

public class Delete : MonoBehaviour {
    public SimulationStore simulationStore;
    public EditSimulation editSimulation;
    public ListenerTool listenerTool;

    private void OnEnable() {
        listenerTool.AddAction("l", () => DeleteSegment());
    }

    private void OnDisable() {
        listenerTool.RemoveAction("l");
    }

    public void DeleteSegment() {
        int index = -1;
        for (int i = 0; i < simulationStore.segmentDomains.Count; i++) {
            if (simulationStore.segmentDomains[i].position == simulationStore.cursorPosition) {
                index = i;
                break;
            }
        }
        if (index == -1) return;
        simulationStore.segmentDomains.RemoveAt(index);
        editSimulation.Reload();
    }
}
