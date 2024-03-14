using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCursorObject : MonoBehaviour
{
    [SerializeField] Vector2 mouseMovement;
    [SerializeField] float updatedY, updatedX, savedZPos = 3;
    [SerializeField] float maxXDistance = 3, maxYDistance = 2;
    [Tooltip("for the speed of movement of the object")]
    [SerializeField] float xSpeedFactor = 1, ySpeedFactor = 1;

    [Tooltip("for showing and hiding the cursor mouse:")]
    [SerializeField] bool showCursor = false;

    // Start is called before the first frame update

    private void ResetObject()
    {
        updatedX = 0;
        updatedY = 0;
        transform.localPosition = new Vector3(updatedX, updatedY, savedZPos);
    }
    void Start()
    {
        ResetObject();
    }
    private void OnEnable()
    {
        ResetObject();
    }
    private void OnDisable()
    {
        ResetObject();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = showCursor;

        mouseMovement = Mouse.current.delta.ReadValue();
        updatedY += mouseMovement.y * ySpeedFactor; // * Time.deltaTime
        updatedX += mouseMovement.x * xSpeedFactor; // * Time.deltaTime
        if (Mathf.Abs(updatedY) > maxYDistance)
        {
            if (updatedY < 0) updatedY = -maxYDistance;
            else { updatedY = maxYDistance; }
        }

        if (Mathf.Abs(updatedX) > maxXDistance)
        {
            if (updatedX < 0) updatedX = -maxXDistance;
            else { updatedX = maxXDistance; }
        }
        transform.localPosition = new Vector3(updatedX, updatedY, savedZPos);

    }

    //this function has no use for now, delete later if nothing changes:
    public void SetSavedZPos(float zPos) { savedZPos = zPos; }
}
