using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] string TutorialLevelName = "Tutorial";
    [SerializeField] GameObject levelSelect;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        levelSelect.SetActive(true);
    }


    public void QuitGame()
    {
        Debug.Log("game ended");
        Application.Quit();
    }
}
