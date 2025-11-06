using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void OnCreate() {
        SceneManager.LoadScene("CreateMenu");
    }

    public void OnLoad() {
        SceneManager.LoadScene("LoadMenu");
    }

    public void OnControl() {
        SceneManager.LoadScene("ControlMenu");
    }

    public void OnAuthor() {
        SceneManager.LoadScene("AuthorMenu");
    }

    public void OnExit() {
        Application.Quit();
    }
}
