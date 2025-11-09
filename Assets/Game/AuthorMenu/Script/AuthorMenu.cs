using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthorMenu : MonoBehaviour {
    public void OnBack() {
        SceneManager.LoadScene("MainMenu");
    }
}
