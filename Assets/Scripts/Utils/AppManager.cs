using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class AppManager : MonoBehaviour {
    public void Quit() {
        Application.Quit();
    }

    public T GetPlayerPrefs<T>(string key) {
        if (!PlayerPrefs.HasKey(key)) {
            throw new Exception($"No data found in PlayerPrefs under the key: {key}");
        }
        string json = PlayerPrefs.GetString(key);
        if (string.IsNullOrEmpty(json)) {
            throw new Exception($"Empty JSON found under the key: {key}");
        }
        try {
            return JsonUtility.FromJson<T>(json);
        }
        catch (System.Exception e) {
            throw new Exception($"Error parsing JSON from PlayerPrefs (key: {key})\n{e}");
        }
    }

    public void LoadScene<T>(T data, string name, string scene) {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(name, json);
        PlayerPrefs.Save();
        SceneManager.LoadScene(scene);
    }

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }
}
