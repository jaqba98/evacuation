using UnityEngine;

public class DisableSpawns : MonoBehaviour {
    public SimulationStore simulationStore;
    
    public void Init() {
        foreach (GameObject spawn in simulationStore.spawns) {
            spawn.SetActive(false);
        }
    }
}

