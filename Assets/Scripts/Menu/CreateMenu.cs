using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

public class CreateMenu : MonoBehaviour {
    public Button createButton; 
    public TMP_Text messageText;
    public TMP_InputField nameInputField;

    private string[] simulations;
    private string name;
    private bool isValid = false;

    private void Awake() {
        GetSimulationNames();
        NameInputFieldValidate();
    }

    public void OnCreate() {
        if (!isValid) return;
        string fullPath = Path.Combine(Application.dataPath, "simulations", $"{name}.json");
        PlayerPrefs.SetString("simulationName", fullPath);
        PlayerPrefs.SetString("simulationType", "create");
        PlayerPrefs.Save();
        SceneManager.LoadScene("LoadSimulation");
    }

    public void OnBack() {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnNameInputFieldValueChange() {
        NameInputFieldValidate();
    }

    private void NameInputFieldValidate() {
        name = nameInputField.text;
        if (name == "") {
            CreateErrorMessage("The name cannot be empty");
            return;
        }
        if (SimulationExists()) {
            CreateErrorMessage($"The {name} simulation already exist");
            return;
        }
        CreateSuccessMessage("The name is correct");
    }

    private bool SimulationExists() {
        return Array.Exists(simulations, simulation => simulation.EndsWith(name));
    }

    private void CreateErrorMessage(string message) {
        messageText.text = message;
        messageText.color = Color.red;
        createButton.interactable = false;
        isValid = false;
    }

    private void CreateSuccessMessage(string message) {
        messageText.text = message;
        createButton.interactable = true;
        messageText.color = new Color(0f, 0.5f, 0f);
        isValid = true;
    }

    private void GetSimulationNames() {
        string path = Path.Combine(Application.dataPath, "simulations");
        if (Directory.Exists(path)) {
            simulations = Directory.GetFiles(path, "*.json")
                .Select(file => Path.GetFileNameWithoutExtension(file))
                .ToArray();
        } else {
            simulations = new string[0];
        }
    }
}
