using UnityEngine;

public class Cursor : MonoBehaviour {
    public SimulationStore simulationStore;
    public EditSimulation editSimulation;
    public ListenerTool listenerTool;
    public DomainManager domainManager;

    public void Init() {
        simulationStore.cursorPosition = domainManager.simulationDomain.cursorPosition;
    }

    public void Reload() {
        transform.position = simulationStore.cursorPosition;
    }

    private void OnEnable() {
        listenerTool.AddAction("w", () => Move(Vector3.forward));
        listenerTool.AddAction("s", () => Move(Vector3.back));
        listenerTool.AddAction("a", () => Move(Vector3.left));
        listenerTool.AddAction("d", () => Move(Vector3.right));
    }

    private void OnDisable() {
        listenerTool.RemoveAction("w");
        listenerTool.RemoveAction("s");
        listenerTool.RemoveAction("a");
        listenerTool.RemoveAction("d");
    }

    private void Move(Vector3 direction) {
        if (direction == Vector3.forward && simulationStore.cursorPosition.z >= simulationStore.maxCursorPositionUp) return;
        if (direction == Vector3.back && simulationStore.cursorPosition.z <= simulationStore.maxCursorPositionDown) return;
        if (direction == Vector3.left && simulationStore.cursorPosition.x <= simulationStore.maxCursorPositionLeft) return;
        if (direction == Vector3.right && simulationStore.cursorPosition.x >= simulationStore.maxCursorPositionRight) return;
        simulationStore.cursorPosition += (direction * simulationStore.segmentSize);
        editSimulation.Reload();
    }
}
