// using UnityEngine;
// using System.Collections.Generic;

// public class SpawnAgents : MonoBehaviour {
//     public SimulationStore simulationStore;
//     public GameObject agentPrefab;

//     public void Init() {
//         simulationStore.people = simulationStore.spawns.Count;
//         foreach (GameObject spawn in simulationStore.spawns) {
//             GameObject instance = Instantiate(agentPrefab, spawn.transform.position, spawn.transform.rotation);
//             instance.transform.SetParent(this.transform);
//             Agent agentScript = instance.GetComponent<Agent>();
//             if (agentScript != null) {
//                 agentScript.simulationStore = simulationStore;
//             }
//         }
//     }

//     public void Reload() {
//         GameObject[] foundAgents = GameObject.FindGameObjectsWithTag("Agent");
//         simulationStore.agents = new List<GameObject>(foundAgents);
//         if (simulationStore.currentAgent >= simulationStore.agents.Count) {
//             simulationStore.currentAgent = simulationStore.agents.Count - 1;
//         }
//         if (simulationStore.agents.Count == 0) {
//             simulationStore.currentAgent = -1;
//         }
//     }

//     public void Next() {
//         Reload();
//         if (simulationStore.agents.Count == 0) return;
//         simulationStore.currentAgent++;
//         if (simulationStore.currentAgent >= simulationStore.agents.Count) {
//             simulationStore.currentAgent = 0;
//         }
//     }

//     public void Back() {
//         Reload();
//         if (simulationStore.agents.Count == 0) return;
//         simulationStore.currentAgent--;
//         if (simulationStore.currentAgent < 0) {
//             simulationStore.currentAgent = simulationStore.agents.Count - 1;
//         }
//     }
// }
