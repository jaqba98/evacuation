using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LoadMenu : MonoBehaviour {
    public Transform content;
    public GameObject prefab;
    public TMP_InputField panicInputField;
    public TMP_InputField timerInputField;
    public TMP_InputField filterInputField;

    private string[] simulations;

    private void Awake() {
        GetSimulationNames();
        GenerateScrollView();
    }
    
    public void OnBack() {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnFilter() {
        GetSimulationNames();
        GenerateScrollView();
    }

    private void GetSimulationNames() {
        string path = Path.Combine(Application.dataPath, "simulations");
        if (Directory.Exists(path)) {
            simulations = Directory.GetFiles(path, "*.json")
                .Where(file => Path.GetFileNameWithoutExtension(file).Contains(filterInputField.text))
                .ToArray();
        } else {
            simulations = new string[0];
        }
    }

    public void GenerateScrollView()
    {
        foreach (Transform child in content) {
            Destroy(child.gameObject);
        }
        foreach (string simulation in simulations) {
            GameObject newItem = Instantiate(prefab, content);
            TMP_Text titleText = newItem.transform.Find("TitleText").GetComponent<TMP_Text>();
            if (titleText != null) {
                titleText.text = Path.GetFileNameWithoutExtension(simulation);
            }
            Button startButton = newItem.transform.Find("StartButton").GetComponent<Button>();
            if (startButton != null) {
                startButton.onClick.AddListener(() => {
                    PlayerPrefs.SetString("simulationName", simulation);
                    PlayerPrefs.SetString("simulationPanic", panicInputField.text);
                    PlayerPrefs.SetString("simulationTimer", timerInputField.text);
                    PlayerPrefs.SetString("simulationType", "start");
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("LoadSimulation");
                });
            }
            Button editButton = newItem.transform.Find("EditButton").GetComponent<Button>();
            if (editButton != null) {
                editButton.onClick.AddListener(() => {
                    PlayerPrefs.SetString("simulationName", simulation);
                    PlayerPrefs.SetString("simulationType", "edit");
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("LoadSimulation");
                });
            }
            Button deleteButton = newItem.transform.Find("DeleteButton").GetComponent<Button>();
            if (deleteButton != null) {
                deleteButton.onClick.AddListener(() => {
                    if (File.Exists(simulation)) {
                        File.Delete(simulation);
                        OnFilter();
                    }
                });
            }
        }
    }
}
