using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class DefenseMechanism : MonoBehaviour
{

    [SerializeField] private GameObject katanaStartingPose;
    [SerializeField] Transform rotateDirection;

    [SerializeField] GameObject cursorObject;

    [Header("These fields are for display only")]
    [SerializeField] private Vector3 positionMinusMouse;
    [SerializeField] private Vector3 positionMinusCursor;
    [SerializeField] private float screenZCoordinate;
    [SerializeField] private float ZCoordinate;
    [SerializeField] private float distanceToCenterDivider = 1;
  //  [SerializeField] private float ZOffSet = 1;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Cursor.visible = true;

    }

/*    public void OnEnable()
    {
        if (Input.GetMouseButton(1))
        {
            ResetSwordPosition();

            cursorObject.SetActive(true);

            screenZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            positionMinusMouse = transform.position - MousePositionOnWorld();

        }
    }*/

    void Update()
    {

        //defense uses right click, left click will be for future attackings with the sword
        if (Input.GetMouseButtonDown(1))
        {
            ResetSwordPosition();

            cursorObject.SetActive(true);

            screenZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            positionMinusMouse = transform.position - MousePositionOnWorld();

        }
        if (Input.GetMouseButton(1)) 
        {
            transform.position = positionMinusMouse / distanceToCenterDivider + MousePositionOnWorld();
            transform.LookAt(rotateDirection);
        }
        if (Input.GetMouseButtonUp(1)) 
        {
            cursorObject.SetActive(false);

            ResetSwordPosition();

        }

    }

    private Vector3 MousePositionOnWorld()
    {
        Vector3 mouseOnScreen = Camera.main.WorldToScreenPoint(cursorObject.transform.position);    // Screen coordinates of mouse (x,y)
        mouseOnScreen.z = screenZCoordinate;            // z coordinate of game object on screen
        Vector3 mouseOnWorld = Camera.main.ScreenToWorldPoint(mouseOnScreen); //converts the screen position into world position
        return mouseOnWorld;
    }
 
    private void ResetSwordPosition()
    {
        // resets the sword
        rb.isKinematic = true;
        transform.position = katanaStartingPose.transform.position;
        transform.rotation = katanaStartingPose.transform.rotation;
        rb.isKinematic = false;
    }
}

