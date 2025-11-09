using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;

public class CreateMenu : MonoBehaviour {
    [Header("Tool")]
    public FileTool fileTool;

    [Header("Control")]
    public TMP_InputField nameInputField;
    public TMP_Text messageText;
    public Button createButton;

    private bool fieldIsValid;
    public string filePath;

    public void Awake() {
        Validate();
    }

    public void OnCreate() {
        if (!fieldIsValid) return;
        PlayerPrefs.SetString("simulationFilePath", filePath);
        PlayerPrefs.SetString("simulationType", "create");
        PlayerPrefs.Save();
        SceneManager.LoadScene("LoadSimulation");
    }

    public void OnBack() {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnValueChange() {
        Validate();
    }

    private void Validate() {
        filePath = "";
        string name = nameInputField.text;
        if (name == "") {
            CreateErrorMessage("The name cannot be empty");
            return;
        }
        string[] simulationMapFiles = fileTool.GetSimulationMapFiles();
        string simulationMapFileName = fileTool.BuildSimulationMapFileName(name);
        bool simulationMapFileExists = Array.Exists(simulationMapFiles, simulationMapFile => simulationMapFile.EndsWith(simulationMapFileName));
        if (simulationMapFileExists) {
            CreateErrorMessage($"The {name} simulation already exist");
            return;
        }
        CreateSuccessMessage("The name is correct");
        filePath = fileTool.BuildSimulationMapFilePath(name);
    }

    private void CreateErrorMessage(string message) {
        messageText.text = message;
        messageText.color = Color.red;
        fieldIsValid = false;
        createButton.interactable = false;
    }

    private void CreateSuccessMessage(string message) {
        messageText.text = message;
        messageText.color = new Color(0f, 0.5f, 0f);
        fieldIsValid = true;
        createButton.interactable = true;
    }
}
