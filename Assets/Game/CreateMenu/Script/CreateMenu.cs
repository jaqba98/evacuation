using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class CreateMenu : MonoBehaviour {
    public Button createButton;
    public NameInputField nameInputField;

    public void OnCreate() {
        if (!nameInputField.fieldIsValid) return;
        string fullPath = Path.Combine(Application.dataPath, "simulations", $"{name}.json");
        PlayerPrefs.SetString("simulationFullPath", fullPath);
        PlayerPrefs.SetString("simulationType", "create");
        PlayerPrefs.Save();
        SceneManager.LoadScene("LoadSimulation");
    }

    public void OnBack() {
        SceneManager.LoadScene("MainMenu");
    }
}
