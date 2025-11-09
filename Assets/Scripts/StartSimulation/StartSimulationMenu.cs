// using UnityEngine;
// using UnityEngine.SceneManagement;
// using System.Collections.Generic;
// using System.Collections;

// public class StartSimulationMenu : MonoBehaviour {
//     public SimulationStore simulationStore;

//     [Header("Services")]
//     public Timer timer;
//     public Segments segments;
//     public SpawnAgents spawnAgents;
//     public DisableSpawns disableSpawns;
//     public BakeTerrain bakeTerrain;
//     public Status status;

//     void Start() {
//         Init();
//         StartCoroutine(RunTimer());
//     }
    
//     private IEnumerator RunTimer() {
//         while (simulationStore.simulationTimer > 0) {
//             yield return new WaitForSeconds(1f);
//             simulationStore.simulationTimer--;
//             Reload();
//             if (simulationStore.survivors >= simulationStore.people) {
//                 break;
//             }
//         }
//         OnExit();
//     }

//     private void Init() {
//         segments.Init();
//         spawnAgents.Init();
//         disableSpawns.Init();
//         bakeTerrain.Init();
//     }

//     private void Reload() {
//         timer.Reload();
//         status.Reload();
//         spawnAgents.Reload();
//     }
    
//     private void OnExit() {
//         PlayerPrefs.SetInt("summaryTimer", simulationStore.simulationTimer);
//         PlayerPrefs.SetInt("summaryPeople", simulationStore.people);
//         PlayerPrefs.SetInt("summarySurvivors", simulationStore.survivors);
//         PlayerPrefs.SetInt("summaryExits", simulationStore.exits.Count);
//         PlayerPrefs.SetFloat("summaryPanic", simulationStore.panic);
//         SceneManager.LoadScene("SummarySimulation");
//     }

//     public void Update() {
//         if (simulationStore.currentAgent < simulationStore.agents.Count && simulationStore.agents[simulationStore.currentAgent]) {
//             float x = simulationStore.agents[simulationStore.currentAgent].transform.position.x;
//             float y = simulationStore.agents[simulationStore.currentAgent].transform.position.y + 10.0f;
//             float z = simulationStore.agents[simulationStore.currentAgent].transform.position.z - 5.0f;
//             Camera.main.transform.localPosition = new Vector3(x, y, z);
//             Camera.main.transform.LookAt(simulationStore.agents[simulationStore.currentAgent].transform);
//         }
//     }

//     public void Exit() {
//         SceneManager.LoadScene("MainMenu");
//     }
// }
