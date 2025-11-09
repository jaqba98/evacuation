using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour {
    public FileTool fileTool;
    public Transform content;
    public GameObject contentItemPrefab;

    public string[] simulations;

    private void Awake() {
        simulations = fileTool.GetSimulationMapFiles();
        GenerateScrollView();
    }

    public void OnBack() {
        SceneManager.LoadScene("MainMenu");
    }

    public void GenerateScrollView() {
        foreach (Transform child in content) {
            Destroy(child.gameObject);
        }
        foreach (string simulation in simulations) {
            GameObject newContentItemPrefab = Instantiate(contentItemPrefab, content);
            TMP_Text titleText = newContentItemPrefab.transform.Find("TitleText").GetComponent<TMP_Text>();
            titleText.text = Path.GetFileNameWithoutExtension(simulation);
            Button startButton = newContentItemPrefab.transform.Find("StartButton").GetComponent<Button>();
            startButton.onClick.AddListener(() => {
                PlayerPrefs.SetString("simulationFilePath", simulation);
                PlayerPrefs.SetString("simulationType", "start");
                PlayerPrefs.Save();
                SceneManager.LoadScene("LoadSimulation");
            });
            Button editButton = newContentItemPrefab.transform.Find("EditButton").GetComponent<Button>();
            editButton.onClick.AddListener(() => {
                PlayerPrefs.SetString("simulationFilePath", simulation);
                PlayerPrefs.SetString("simulationType", "edit");
                PlayerPrefs.Save();
                SceneManager.LoadScene("LoadSimulation");
            });
            Button deleteButton = newContentItemPrefab.transform.Find("DeleteButton").GetComponent<Button>();
            deleteButton.onClick.AddListener(() => {
                PlayerPrefs.SetString("simulationFilePath", simulation);
                PlayerPrefs.SetString("simulationType", "delete");
                PlayerPrefs.Save();
                SceneManager.LoadScene("LoadSimulation");
            });
        }
    }
}
