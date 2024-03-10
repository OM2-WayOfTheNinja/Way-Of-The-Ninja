using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BringUpSettingImproved : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] GameObject weapon;
    [SerializeField] bool isWeaponEnabledThisScene;
    [SerializeField] InputAction settingsKey;
    [SerializeField] bool settingsKeyIsPressed = false;
    [SerializeField] GameObject setting;
    [SerializeField] bool isSettingActive;
    [SerializeField] Button mainMenuButton;

    void OnEnable() { settingsKey.Enable(); }
    void OnDisable() { settingsKey.Disable(); }
    // Start is called before the first frame update
    void Start()
    {
      
        mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
      
    
    }

    // Update is called once per frame
    void Update()
    {
        if (settingsKey.IsPressed() && settingsKeyIsPressed == false) 
        {
            settingsKeyIsPressed = true;
            if (isSettingActive == false)
            {
                Pause();
            }
            else {
                Resume();
             }
         }
         else if(settingsKey.IsPressed() == false)
         {
            settingsKeyIsPressed = false;
         }
    }

    private void Pause()
    {
        setting.SetActive(true);
        isSettingActive = true;
       // cam.GetComponent<LookX>().enabled = false;
       // cam.GetComponent<LookY>().enabled = false;
        cam.GetComponent<CameraRotation>().enabled = false;
        Debug.Log("shutting off cam movement");
        weapon.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    
        
    }

    private void Resume()
    {
        setting.SetActive(false);
        isSettingActive = false;
      //  cam.GetComponent<LookX>().enabled = true;
       // cam.GetComponent<LookY>().enabled = true;
        cam.GetComponent<CameraRotation>().enabled = true;
        weapon.SetActive(isWeaponEnabledThisScene);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
     
    
    }
}
