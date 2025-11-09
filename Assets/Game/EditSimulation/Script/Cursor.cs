using UnityEngine;

public class Cursor : MonoBehaviour {
    public SimulationStore simulationStore;
    public EditSimulation editSimulation;
    public Listener listener;
    public DomainManager domainManager;

    public void Init() {
        simulationStore.cursorPosition = domainManager.simulationDomain.cursorPosition;
    }

    public void Reload() {
        transform.position = simulationStore.cursorPosition;
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
        simulationStore.cursorPosition += (direction * simulationStore.segmentSize);
        editSimulation.Reload();
    }
}
