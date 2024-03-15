using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, pauseMenuMain, pauseMenuSettings;

    [SerializeField] GameObject cam;
    [SerializeField] GameObject weapon;
    [SerializeField] bool isWeaponEnabledThisScene;
    [SerializeField] string mainMenuName = "MainMenu";


    bool m_paused = false;

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;
        if (keyboard.tabKey.wasPressedThisFrame)
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        if (m_paused)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            cam.GetComponent<CameraRotation>().enabled = true;
            weapon.SetActive(isWeaponEnabledThisScene);
            Time.timeScale = 1.0f;

            pauseMenu.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            cam.GetComponent<CameraRotation>().enabled = false;
            Debug.Log("shutting off cam movement");
            weapon.SetActive(false);
            Cursor.visible = true;
            Time.timeScale = 0.0f;

            pauseMenu.SetActive(true);
        }
        m_paused = !m_paused;
    }
    public void SettingsBackOnClick()
    {
        pauseMenuSettings.SetActive(false);
        pauseMenuMain.SetActive(true);
    }


    public void ResumeOnClick()
    {
        TogglePauseMenu();
    }

    public void SettingsOnClick()
    {
        pauseMenuMain.SetActive(false);
        pauseMenuSettings.SetActive(true);
    }

    public void ExitToMainOnClick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(mainMenuName);
    }
}
