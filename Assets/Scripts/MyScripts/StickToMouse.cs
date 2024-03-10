using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class StickToMouse : MonoBehaviour
{

    [SerializeField] private GameObject anchorStartingPose;
   // [SerializeField] Transform rotateDirection;

    [SerializeField] GameObject cursorObject;

    [Header("These fields are for display only")]
    [SerializeField] private Vector3 positionMinusMouse;
    [SerializeField] private Vector3 positionMinusCursor;
    [SerializeField] private float screenZCoordinate;
    [SerializeField] private float ZCoordinate;
    [SerializeField] private float distanceToCenterDivider = 1;
    [SerializeField] private float ZOffSet = 3;

    [SerializeField] float xFactor = 2;
    [SerializeField] float yFactor = 2;
  //  [SerializeField] float zFactor = 2;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ResetPosition();

        // Cursor.visible = true;

    }


    void Update()
    {

        //defense uses right click, left click will be for future attackings with the sword
        if (Input.GetMouseButtonDown(0)) // || Input.GetMouseButtonDown(0))
        {
            ResetPosition();


            //Cursor.lockState = CursorLockMode.Confined;
           // Cursor.visible = true;
            //cursorObject.GetComponent<MoveCursorObject>().enabled = true;
            cursorObject.SetActive(true);

            screenZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            positionMinusMouse = transform.position - MousePositionOnWorld();

        }
        if (Input.GetMouseButton(0) )// || Input.GetMouseButton(0))
        {
            Vector3 newPos = cursorObject.transform.position;
          //  newPos.x *= xFactor;
           // newPos.y *= yFactor;
            //newPos.z *= zFactor;
            
            transform.position = newPos;
            transform.position = positionMinusMouse / distanceToCenterDivider + MousePositionOnWorld();
            //transform.LookAt(rotateDirection);
        }
        if (Input.GetMouseButtonUp(0)) // || Input.GetMouseButtonUp(0))
        {
            // Debug.Log("mouse released");
            Cursor.lockState = CursorLockMode.Locked;
            //cursorObject.GetComponent<MoveCursorObject>().enabled = false;
            cursorObject.SetActive(false);

            ResetPosition();

        }

    }

    private Vector3 MousePositionOnWorld()
    {
        Vector3 mouseOnScreen = Camera.main.WorldToScreenPoint(cursorObject.transform.position);    // Screen coordinates of mouse (x,y)
        mouseOnScreen.x *= xFactor;
        mouseOnScreen.y *= yFactor;
        mouseOnScreen.z = screenZCoordinate +ZOffSet;            // z coordinate of game object on screen
        //  newPos.x *= xFactor;
        // newPos.y *= yFactor;
        //newPos.z *= zFactor;

        Vector3 mouseOnWorld = Camera.main.ScreenToWorldPoint(mouseOnScreen); //converts the screen position into world position
        return mouseOnWorld;
    }
    private Vector3 CursorPositionOnWorld()
    {
        Vector3 cursorOnScreen = cursorObject.transform.position;    // Screen coordinates of mouse (x,y)
        cursorOnScreen.z = screenZCoordinate;            // z coordinate of game object on screen
        Vector3 CursorOnWorld = Camera.main.ScreenToWorldPoint(cursorOnScreen);
        // Camera.main.ScreenToWorldPoint(cursorOnScreen); //converts the screen position into world position

        return CursorOnWorld;
    }

    private void ResetPosition()
    {
        // resets the object
        rb.isKinematic = true;
        transform.position = anchorStartingPose.transform.position;
        transform.rotation = anchorStartingPose.transform.rotation;
        rb.isKinematic = false;
    }
}

