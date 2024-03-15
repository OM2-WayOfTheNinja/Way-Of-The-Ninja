using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    [SerializeField] InputAction RetryButton;
    //[SerializeField] string retryScene = "Tutorial";
    [SerializeField] string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        RetryButton.Enable();
    }

    private void OnDisable()
    {
        RetryButton.Disable();
    }
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("tried to quit");
            Application.Quit();
        }
        // if(RetryButton!=null)
        // if (RetryButton.ReadValue<float>() > 0) 
        // {
        //     SceneManager.LoadScene(retryScene);    // Input can either be a serial number or a name; here we use name.

        // }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
