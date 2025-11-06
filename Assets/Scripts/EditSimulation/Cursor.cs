using UnityEngine;

public class Cursor : MonoBehaviour {
    public SimulationStore simulationStore;
    public Listener listener;
    public EditSimulationMenu editSimulationMenu;

    public void Reload() {
        Vector3 cursorPosition =  new Vector3(simulationStore.cursorPositionX, 0.0f, simulationStore.cursorPositionZ);
        transform.position = cursorPosition;
    }

    private void OnEnable() {
        listener.AddAction("w", () => Move(Vector3.forward));
        listener.AddAction("s", () => Move(Vector3.back));
        listener.AddAction("a", () => Move(Vector3.left));
        listener.AddAction("d", () => Move(Vector3.right));
    }

    private void OnDisable() {
        listener.RemoveAction("w");
        listener.RemoveAction("s");
        listener.RemoveAction("a");
        listener.RemoveAction("d");
    }

    private void Move(Vector3 direction) {
        if (simulationStore.frozen) return;
        if (direction == Vector3.left && simulationStore.cursorPositionX <= -504) return;
        if (direction == Vector3.right && simulationStore.cursorPositionX >= 504) return;
        if (direction == Vector3.forward && simulationStore.cursorPositionZ >= 504) return;
        if (direction == Vector3.back && simulationStore.cursorPositionZ <= -504) return;
        Vector3 cursorPosition =  new Vector3(simulationStore.cursorPositionX, 0.0f, simulationStore.cursorPositionZ);
        Vector3 newCursorPosition = cursorPosition + (direction * simulationStore.segmentSize);
        simulationStore.cursorPositionX = newCursorPosition.x;
        simulationStore.cursorPositionZ = newCursorPosition.z;
        simulationStore.canBuildSegment = true;
        editSimulationMenu.Reload();
    }
}
