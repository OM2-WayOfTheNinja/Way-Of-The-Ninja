using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


/**
 * This component moves a player controlled with a CharacterController using the keyboard.
 */
[RequireComponent(typeof(CharacterController))]
public class CharacterKeyboardMover: MonoBehaviour {

    [Tooltip("Speed of player keyboard-movement, in meters/second")]
    [SerializeField] float speed = 3.5f;
    
    [Tooltip("Speed of player jump-movement, in meters/second")]
    [SerializeField] float jumpPower = 5;
    
    [SerializeField] float gravity = 9.81f;

    private CharacterController cc;

   // [SerializeField] GameObject runningEffect;
    [SerializeField] InputAction moveAction;
    [SerializeField] InputAction runAction;
    [SerializeField] float runSpeed = 3f;
    [SerializeField] InputAction jumpAction;
    private void OnEnable() { moveAction.Enable(); jumpAction.Enable(); runAction.Enable(); }
    private void OnDisable() { moveAction.Disable(); jumpAction.Disable(); runAction.Disable(); }
    void OnValidate() {
        // Provide default bindings for the input actions.
        // Based on answer by DMGregory: https://gamedev.stackexchange.com/a/205345/18261
        if (moveAction == null)
            moveAction = new InputAction(type: InputActionType.Button);
        if (moveAction.bindings.Count == 0)
            moveAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/upArrow")
                .With("Down", "<Keyboard>/downArrow")
                .With("Left", "<Keyboard>/leftArrow")
                .With("Right", "<Keyboard>/rightArrow");
    }

    void Start() {
        cc = GetComponent<CharacterController>();
      //  runningEffect.SetActive(false);
    }

    Vector3 velocity = new Vector3(0,0,0);
    Vector3 velocityJump = new Vector3(0,0,0);

    void Update()  {
        if (cc.isGrounded) {
            Jump();
                      
        } else {
            velocity.y -= gravity*Time.deltaTime;
        }
        Move();

        // Move in the direction you look:
        velocity = transform.TransformDirection(velocity);
        cc.Move(velocity * Time.deltaTime);
    }

    private void Move() 
    {
        Vector3 movement = moveAction.ReadValue<Vector2>(); // Implicitly convert Vector2 to Vector3, setting z=0.
        float newSpeed = speed  + runAction.ReadValue<float>() * runSpeed;
      //  runningEffect.SetActive(runAction.ReadValue<float>() > 0);
        velocity.x = movement.x * newSpeed; 
        velocity.z = movement.y * newSpeed;
    }

    private void Jump() 
    {
        if (!cc.isGrounded) return;
       
            velocity.y = jumpAction.ReadValue<float>() * jumpPower;
        velocityJump.y = jumpAction.ReadValue<float>() * jumpPower;
       // Debug.Log("jump value is: " + jumpAction.ReadValue<float>() * jumpPower);

    }
}
