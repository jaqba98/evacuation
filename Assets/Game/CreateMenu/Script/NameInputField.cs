using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class NameInputField : MonoBehaviour {
    public GetAllSimulations getAllSimulations;
    public TMP_InputField nameInputField;
    public TMP_Text messageText;
    public Button createButton;
    public bool fieldIsValid;

    public void Awake() {
        OnValueChange();
    }

    public void OnValueChange() {
        Validate();
    }

    private void Validate() {
        string text = nameInputField.text;
        if (text == "") {
            CreateErrorMessage("The name cannot be empty");
            return;
        }
        string[] simulations = getAllSimulations.GetSimulations();
        bool simulationExists = Array.Exists(simulations, simulation => simulation.EndsWith(name));
        if (simulationExists) {
            CreateErrorMessage($"The {name} simulation already exist");
            return;
        }
        CreateSuccessMessage("The name is correct");
    }

    private void CreateErrorMessage(string error) {
        messageText.text = error;
        messageText.color = Color.red;
        fieldIsValid = false;
        createButton.interactable = false;
    }

    private void CreateSuccessMessage(string success) {
        messageText.text = success;
        messageText.color = new Color(0f, 0.5f, 0f);
        fieldIsValid = true;
        createButton.interactable = true;
    }
}
