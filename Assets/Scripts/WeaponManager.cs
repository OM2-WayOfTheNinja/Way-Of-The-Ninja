using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{

    [SerializeField] InputAction[] weaponButtons;
    [SerializeField] GameObject[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        SwitchToWeapon(0);
    }
    void OnEnable() 
    {
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            weaponButtons[i].Enable();
        }
    }
    
    void OnDisable() 
    {
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            weaponButtons[i].Disable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            if (weaponButtons[i].ReadValue<float>() > 0) 
            {
                SwitchToWeapon(i);
                break;
            }
        }
    }
    void SwitchToWeapon(int index) 
    {
        weapons[index].SetActive(true);
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i != index) { weapons[i].SetActive(false); }
        }
    }
}
