using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {
    public SimulationStore simulationStore;
    public TextMeshProUGUI timerText;

    public void Reload() {
        timerText.text = $"{simulationStore.simulationTimer} s";
    }
}
