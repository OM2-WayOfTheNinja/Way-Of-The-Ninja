using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] Vector2 mouseMovement;
    [SerializeField] float xRotation, yRotation;
    [SerializeField] float mouseSensitivity = 5;
    [SerializeField] Slider sensitivityBar;
    [SerializeField] float lookUpBound = 90,lookDownBound = -90;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
                  //  Cursor.visible = true;

    }

    // Update is called once per frame
    void LateUpdate() //Update()
    {
        mouseMovement = Mouse.current.delta.ReadValue();
        xRotation += mouseMovement.y * mouseSensitivity * sensitivityBar.value; // * Time.deltaTime ;
        xRotation = Mathf.Clamp(xRotation, lookDownBound, lookUpBound);
        yRotation += mouseMovement.x * mouseSensitivity * sensitivityBar.value;  //* Time.deltaTime;
        yRotation = yRotation % 360;
        transform.rotation = Quaternion.Euler(-xRotation, yRotation, 0);
        player.transform.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}