using UnityEngine;


public class Mover : MonoBehaviour
{

    [SerializeField] float forceSize = 100f;
    [SerializeField] ForceMode forceMode = ForceMode.Force;
    [SerializeField] float torqueSize = 100f;
    [SerializeField] ForceMode torqueMode = ForceMode.Force;

    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;

    [SerializeField] AudioClip[] throwSounds;


    private Rigidbody rb;
    void Start()
    {

        AudioSource as1 = GetComponent<AudioSource>();
        as1.clip = throwSounds[Random.Range(0, throwSounds.Length)];
        as1.Play();

        rb = GetComponent<Rigidbody>();

        //shoots the ninja star towards the player's position
        Vector3 dir = player.transform.position - transform.position + offset;
        dir = dir.normalized;
        rb.AddForce(dir * forceSize, forceMode);
        rb.AddTorque(dir * torqueSize, torqueMode);
    }
}
