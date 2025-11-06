using UnityEngine;

public class Rotate : MonoBehaviour {
    public SimulationStore simulationStore;
    public EditSimulationMenu editSimulationMenu;
    public Listener listener;

    public void Reload() {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y = simulationStore.cursorRotation;
        transform.eulerAngles = currentRotation;
    }

    private void OnEnable() {
        listener.AddAction("q", () => Rotation(-90));
        listener.AddAction("e", () => Rotation(90));
    }

    private void OnDisable() {
        listener.RemoveAction("q");
        listener.RemoveAction("e");
    }

    private void Rotation(float rotation) {
        if (simulationStore.frozen) return;
        simulationStore.cursorRotation += rotation;
        simulationStore.cursorRotation %= 360f;
        if (simulationStore.cursorRotation < 0f) {
            simulationStore.cursorRotation += 360f;
        }
        editSimulationMenu.Reload();
    }
}
