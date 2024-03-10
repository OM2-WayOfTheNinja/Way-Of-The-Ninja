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


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
                  //  Cursor.visible = true;

    }

    // Update is called once per frame
    void Update()
    {
        mouseMovement = Mouse.current.delta.ReadValue();
        xRotation += mouseMovement.y * mouseSensitivity * sensitivityBar.value * Time.deltaTime ;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        yRotation += mouseMovement.x * mouseSensitivity * sensitivityBar.value * Time.deltaTime;
        yRotation = yRotation % 360;
        transform.rotation = Quaternion.Euler(-xRotation, yRotation, 0);
        player.transform.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}