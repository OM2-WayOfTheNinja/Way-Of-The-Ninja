using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] string TutorialLevelName = "Tutorial";

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(TutorialLevelName);
    }

    public void QuitGame()
    {
        Debug.Log("game ended");
        Application.Quit();
    }
}
