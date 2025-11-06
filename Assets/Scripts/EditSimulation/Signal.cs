using UnityEngine;

public class Signal : MonoBehaviour {
    public SimulationStore simulationStore;

    public GameObject signalError;

    public void Reload() {
        if (simulationStore.canBuildSegment) {
            signalError.SetActive(false);
        } else {
            signalError.SetActive(true);
        }
    }
}
