using UnityEngine;

public class Rotation : MonoBehaviour {
    public SimulationStore simulationStore;
    public EditSimulation editSimulation;
    public ListenerTool listenerTool;
    public DomainManager domainManager;

    public void Init() {
        simulationStore.cursorRotation = domainManager.simulationDomain.cursorRotation;
    }

    public void Reload() {
        transform.eulerAngles = simulationStore.cursorRotation;
    }

    private void OnEnable() {
        listenerTool.AddAction("q", () => Move(Vector3.down));
        listenerTool.AddAction("e", () => Move(Vector3.up));
    }

    private void OnDisable() {
        listenerTool.RemoveAction("q");
        listenerTool.RemoveAction("e");
    }

    private void Move(Vector3 direction) {
        simulationStore.cursorRotation += direction * 90.0f;
        simulationStore.cursorRotation.x = (simulationStore.cursorRotation.x % 360f + 360f) % 360f;
        simulationStore.cursorRotation.y = (simulationStore.cursorRotation.y % 360f + 360f) % 360f;
        simulationStore.cursorRotation.z = (simulationStore.cursorRotation.z % 360f + 360f) % 360f;
        editSimulation.Reload();
    }
}
