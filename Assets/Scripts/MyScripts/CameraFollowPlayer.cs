using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] float cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false); 
        cameraOffset = transform.position.y - player.transform.position.y;
        this.gameObject.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 updatedCameraPosition = player.transform.position;
        updatedCameraPosition.y += cameraOffset;
        transform.position = updatedCameraPosition;
    }
}
