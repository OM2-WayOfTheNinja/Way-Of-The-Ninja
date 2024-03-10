using UnityEngine;

public class AimTowardsPlayer : MonoBehaviour
{

    [SerializeField] Transform Player;

    void Update()
    {
        // looks at player the whole game
        transform.LookAt(Player);
    }
}
