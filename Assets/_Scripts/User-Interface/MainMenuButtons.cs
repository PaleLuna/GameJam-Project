using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void StartGame() => SceneManager.LoadScene(2);

    public void Exit() => Application.Quit();
}
