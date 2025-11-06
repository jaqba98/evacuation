using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour {
    public void OnBack() {
        SceneManager.LoadScene("MainMenu");
    }
}
