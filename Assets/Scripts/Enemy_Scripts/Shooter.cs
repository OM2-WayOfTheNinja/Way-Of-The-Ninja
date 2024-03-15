using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.UIElements;

/**
 * This component represents an enemy NPC that chases the player.
 */
[RequireComponent(typeof(NavMeshAgent))]
public class Shooter: MonoBehaviour {

    [Tooltip("The object that this enemy chases after")] [SerializeField]
    GameObject player = null;

    [Header("These fields are for display only")]
    [SerializeField] private Vector3 playerPosition;

    [SerializeField] SphereCollider personalSpace;
    [SerializeField] bool isInPersonalSpace = false;

    [SerializeField] Animator animator;
    private NavMeshAgent navMeshAgent;

    [SerializeField] GameObject ninjaStarSpawner;

    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
        //animator.enabled = false;

    }

        private void OnEnable()
    {
        ninjaStarSpawner.SetActive(true);
        //navMeshAgent.SetDestination(this.transform.position);
        
        animator.Play("Base Layer.idle");
    }
    void OnDisable() 
    {
        ninjaStarSpawner.SetActive(false);

    }

    private void Update() {
        playerPosition = player.transform.position;
       // playerPosition.z = transform.position.z;
        float distanceToPlayer = Vector3.Distance(playerPosition, transform.position);
        FacePlayer();
    }

    private void FacePlayer() {
      //  Vector3 direction = (playerPosition - transform.position).normalized;
       // Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0 , direction.z));
        // // transform.rotation = lookRotation;
       // transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

        //my change:
        transform.LookAt(playerPosition);
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == personalSpace)
        {
            Debug.Log("entered trigger on personal space");
            isInPersonalSpace = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == personalSpace)
        {
            Debug.Log("exit trigger on personal space");

            isInPersonalSpace = false; ;
        }
    }


    public bool IsTooClose() 
    {
        return isInPersonalSpace;
    }

    internal Vector3 TargetObjectPosition() {
        return player.transform.position;
    }

    private void FaceDirection() {
        Vector3 direction = (navMeshAgent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // transform.rotation = lookRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

}
