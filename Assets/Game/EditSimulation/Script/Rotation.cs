using UnityEngine;

public class Rotation : MonoBehaviour {
    public SimulationStore simulationStore;
    public EditSimulation editSimulation;
    public Listener listener;
    public DomainManager domainManager;

    public void Init() {
        simulationStore.cursorRotation = domainManager.simulationDomain.cursorRotation;
    }

    public void Reload() {
        transform.eulerAngles = simulationStore.cursorRotation;
    }

    private void OnEnable() {
        listener.AddAction("q", () => Move(Vector3.down));
        listener.AddAction("e", () => Move(Vector3.up));
    }

    private void OnDisable() {
        listener.RemoveAction("q");
        listener.RemoveAction("e");
    }

    private void Move(Vector3 direction) {
        simulationStore.cursorRotation += direction * 90.0f;
        simulationStore.cursorRotation.x = (simulationStore.cursorRotation.x % 360f + 360f) % 360f;
        simulationStore.cursorRotation.y = (simulationStore.cursorRotation.y % 360f + 360f) % 360f;
        simulationStore.cursorRotation.z = (simulationStore.cursorRotation.z % 360f + 360f) % 360f;
        editSimulation.Reload();
    }
}
