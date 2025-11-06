using UnityEngine;
using UnityEngine.SceneManagement;

public class SummarySimulationMenu : MonoBehaviour {
    public void Restart() {
        SceneManager.LoadScene("StartSimulation");
    }

    public void Exit() {
        SceneManager.LoadScene("MainMenu");
    }
}
