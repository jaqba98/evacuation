using UnityEngine;

public class SimulationCommon : MonoBehaviour {
    public SimulationStore simulationStore;
    public DomainManager domainManager;

    public void Init() {
        simulationStore.segmentSize = 4.0f;
        simulationStore.path = domainManager.simulationDomain.path;
    }
}
