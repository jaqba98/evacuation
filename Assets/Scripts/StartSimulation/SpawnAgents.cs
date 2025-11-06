using UnityEngine;

public class SpawnAgents : MonoBehaviour {
    public SimulationStore simulationStore;
    public GameObject agentPrefab;

    public void Init() {
        simulationStore.people = simulationStore.spawns.Count;
        foreach (GameObject spawn in simulationStore.spawns) {
            GameObject instance = Instantiate(agentPrefab, spawn.transform.position, spawn.transform.rotation);
            instance.transform.SetParent(this.transform);
            Agent agentScript = instance.GetComponent<Agent>();
            if (agentScript != null) {
                agentScript.simulationStore = simulationStore;
            }
        }
    }
}
