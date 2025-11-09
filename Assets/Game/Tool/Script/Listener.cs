using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;

public class Listener : MonoBehaviour {
    private Dictionary<string, InputAction> actions = new Dictionary<string, InputAction>();

    public void AddAction(string key, UnityAction unityAction) {
        if (actions.ContainsKey(key)) return;
        InputAction action = new InputAction(binding: $"<Keyboard>/{key}");
        action.performed += ctx => unityAction();
        action.Enable();
        actions.Add(key, action);
    }

    public void RemoveAction(string action) {
        if (actions.TryGetValue(action, out InputAction inputAction)) {
            inputAction.Disable();
            inputAction.performed -= null;
            actions.Remove(action);
        } else {
            throw new Exception($"The {action} action does not registered!");
        }
    }
}
