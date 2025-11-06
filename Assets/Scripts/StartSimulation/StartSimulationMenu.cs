using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class StartSimulationMenu : MonoBehaviour {
    public SimulationStore simulationStore;

    [Header("Services")]
    public Timer timer;
    public Segments segments;
    public SpawnAgents spawnAgents;
    public DisableSpawns disableSpawns;
    public BakeTerrain bakeTerrain;
    public Status status;

    void Start() {
        Init();
        StartCoroutine(RunTimer());
    }
    
    private IEnumerator RunTimer() {
        while (simulationStore.simulationTimer > 0) {
            yield return new WaitForSeconds(1f);
            simulationStore.simulationTimer--;
            Reload();
            if (simulationStore.survivors >= simulationStore.people) {
                break;
            }
        }
        OnExit();
    }

    private void Init() {
        segments.Init();
        spawnAgents.Init();
        disableSpawns.Init();
        bakeTerrain.Init();
    }

    private void Reload() {
        timer.Reload();
        status.Reload();
    }
    
    private void OnExit() {
        PlayerPrefs.SetInt("summaryTimer", simulationStore.simulationTimer);
        PlayerPrefs.SetInt("summaryPeople", simulationStore.people);
        PlayerPrefs.SetInt("summarySurvivors", simulationStore.survivors);
        PlayerPrefs.SetInt("summaryExits", simulationStore.exits.Count);
        PlayerPrefs.SetFloat("summaryPanic", simulationStore.panic);
        SceneManager.LoadScene("SummarySimulation");
    }

    // public Segments segments;
    // public BakeTerrain bakeTerrain;

    // public List<GameObject> agents = new List<GameObject>();
    // private int currentIndex = 0;

    // public void Start() {
    //     segments.Reload();
    //     bakeTerrain.Reload();
    //     InitAgents();
    //     people = agents.Count;
    // }

    // [Header("Timer Settings")]
    // public float startTime = 60f;

    // [Header("UI")]

    // private float currentTime;
    // private bool isRunning = false;

    // public void Update() {
    //     if (agents[currentIndex]) {
    //         float x = agents[currentIndex].transform.position.x;
    //         float y = agents[currentIndex].transform.position.y + 10.0f;
    //         float z = agents[currentIndex].transform.position.z - 5.0f;
    //         Camera.main.transform.localPosition = new Vector3(x, y, z);
    //         Camera.main.transform.LookAt(agents[currentIndex].transform);
    //     }
    // }

    //     survivors++;
    //     Destroy(agent);
    //     currentIndex = 0;
    //     InitAgents();
    //     if (agents.Count == 0) {
    //         SceneManager.LoadScene("SummarySimulation");
    //     }

    // public void Next() {
    //     if (agents.Count == 0) {
    //         return;
    //     }
    //     currentIndex++;
    //     if (currentIndex >= agents.Count) {
    //         currentIndex = 0;
    //     }
    // }

    // public void Back() {
    //     if (agents.Count == 0) {
    //         return;
    //     }
    //     currentIndex--;
    //     if (currentIndex < 0) {
    //         currentIndex = agents.Count - 1;
    //     }
    // }

    // private void InitAgents() {
    //     GameObject[] foundAgents = GameObject.FindGameObjectsWithTag("Agent");
    //     agents = new List<GameObject>(foundAgents);
    // }

    public void Exit() {
        SceneManager.LoadScene("MainMenu");
    }
}
