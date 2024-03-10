using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    FPS_control input_control;
    //[SerializeField] GameObject ground;
    Vector2 move;
    [SerializeField] bool enablePlayerMove = false;
    [SerializeField] float movement_force;
    [SerializeField] float jumpforce;

    TouchDetector td;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        input_control = new FPS_control();
        input_control.Player_map.Enable();
        rb = GetComponent<Rigidbody>();
        td = GetComponent<TouchDetector>();
        move = Vector2.zero;
    }

    private ForceMode walkForceMode = ForceMode.Force;
    private ForceMode jumpForceMode = ForceMode.Impulse;

    private void OnDisable()
    {
        input_control.Player_map.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enablePlayerMove) playermove();
        if (td.IsTouching() && input_control.Player_map.Jump.ReadValue<float>() > 0)
        {
            Playerjump();
        }
    }

    void playermove()
    {
        move = input_control.Player_map.Movement.ReadValue<Vector2>();
        float forcez = move.x * movement_force * Time.deltaTime;
        float forcex = move.y * movement_force * Time.deltaTime;
        rb.AddForce(transform.forward * forcex, walkForceMode);
        rb.AddForce(transform.right * forcez, walkForceMode);

    }
    void Playerjump()
    {
        rb.AddForce(Vector3.up * jumpforce, jumpForceMode);
    }
}