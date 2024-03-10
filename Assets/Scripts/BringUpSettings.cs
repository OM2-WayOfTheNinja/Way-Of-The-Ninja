using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class BringUpSettings : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] GameObject weapon;
    [SerializeField] bool isWeaponEnabledThisScene;
    [SerializeField] InputAction settingsKey;
    [SerializeField] bool settingsKeyIsPressed = false;
    [SerializeField] GameObject setting;
    [SerializeField] bool isSettingActive;

    void OnEnable() { settingsKey.Enable(); }
    void OnDisable() { settingsKey.Disable(); }
    // Start is called before the first frame update
    void Start()
    {
        
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
    
    }
}