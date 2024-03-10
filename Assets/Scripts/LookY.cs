using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/**
 * This component rotates its object according to the mouse movement in the Y axis, in a given rotation speed.
 */
public class LookY : MonoBehaviour { 
    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] Slider sensitivity;

    [SerializeField] float maxLookDown = -90,maxLookUp = 90, xRotation;
    void Update() {
        float mouseY = Mouse.current.delta.y.ReadValue();
        Vector3 rotation = transform.localEulerAngles;
        //rotation.x -= mouseY * rotationSpeed;
        //xRotation = rotation.x;
        xRotation -= mouseY * rotationSpeed *sensitivity.value;
        
        xRotation = Mathf.Clamp(xRotation, maxLookUp, maxLookDown);
        rotation.x = xRotation;
        // rotation.x = Mathf.Clamp(xRotation, maxLookUp, maxLookDown);
        transform.localEulerAngles = rotation;
    }
}
