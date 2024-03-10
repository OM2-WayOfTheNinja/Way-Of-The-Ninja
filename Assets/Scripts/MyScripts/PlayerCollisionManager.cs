using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{

    [SerializeField] GameObject weapon;
    void Start()
    {
        // makes the player and katana collision to be ignored
        Physics.IgnoreCollision(weapon.GetComponent<Collider>(), GetComponent<Collider>());

    }
}
