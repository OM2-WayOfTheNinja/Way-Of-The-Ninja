using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUsage : MonoBehaviour
{//this script manages between diabling and enabling attacking and defensing related scripts

    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponRef;
    [SerializeField] GameObject cam;
   // [SerializeField] bool unlockCamera = true;

    [SerializeField] int state = 0;


    [Tooltip("for showing and hiding the cursor mouse:")]
    [SerializeField] bool showCursor = false;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = showCursor;


        weapon.transform.position = weaponRef.transform.position;
        weapon.transform.rotation = weaponRef.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //right-clicks:
        if (Input.GetMouseButtonDown(1) && state == 0)
        {
            // weapon.GetComponent<AttackMechanism>().enabled = false;
             Cursor.visible = showCursor;
            //cam.GetComponent<CameraRotation>().enabled = unlockCamera;
            state = 1;
        }
        if (Input.GetMouseButtonUp(1) && state == 1)
        {
           //  weapon.GetComponent<AttackMechanism>().enabled = true;
            Cursor.visible = showCursor;

           // cam.GetComponent<CameraRotation>().enabled = unlockCamera;
            state = 0;


        }

        //left-clicks:
        if (Input.GetMouseButtonDown(0) && state == 0)
        {
           // weapon.GetComponent<DefenseMechanism>().enabled = false;
            Cursor.visible = showCursor;
           // cam.GetComponent<CameraRotation>().enabled = unlockCamera;

            state = 2;

        }
        if (Input.GetMouseButtonUp(0) && state == 2)
        {
          //  weapon.GetComponent<DefenseMechanism>().enabled = true;
            Cursor.visible = showCursor;

            //cam.GetComponent<CameraRotation>().enabled = unlockCamera;
            state = 0;
        }
    }

    
}