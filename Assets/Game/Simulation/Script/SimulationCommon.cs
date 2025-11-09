using UnityEngine;

public class SimulationCommon : MonoBehaviour {
    public SimulationStore simulationStore;

    public void Init() {
        simulationStore.segmentSize = 4.0f;
    }
}
