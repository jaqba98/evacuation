using UnityEngine;

public class DomainManager : MonoBehaviour {
    public SimulationDomain simulationDomain;

    public void PreInit() {
        string simulationDomainJson = PlayerPrefs.GetString("simulationDomain");
        simulationDomain = JsonUtility.FromJson<SimulationDomain>(simulationDomainJson);
    }
}
