using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwordAttackScript : MonoBehaviour
{
    [Tooltip("The object that this enemy chases after")]
    [SerializeField] GameObject player = null;

    [Header("These fields are for display only")]
    [SerializeField] private Vector3 playerPosition;

    [SerializeField] Animator animator;
    private NavMeshAgent navMeshAgent;

   // [SerializeField] string attackAnimation = "enemy_w_sword_attack";
   // [SerializeField] string animatorLayerName = "Base Layer";

    [SerializeField] bool isAttacking = true;
    [SerializeField] bool hasStartedAttacking = false;

    [SerializeField] SphereCollider personalSpace;
    [SerializeField] bool isInPersonalSpace = false;

    public bool IsAttacking() { return !isAttacking; }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
        animator.enabled = true;
    }
    private void OnEnable()
    {
        isAttacking = true;
        hasStartedAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

    }
    private void Attack()
    {
        if(hasStartedAttacking == false) {
           // Debug.Log("in Attack after if");

            //isAttacking = true;
            hasStartedAttacking = true;
        playerPosition = player.transform.position;
        transform.LookAt(playerPosition);
           // transform.localScale = Vector3.one * 5;
        navMeshAgent.SetDestination(this.transform.position);
            animator.Play("Base Layer.enemy_w_sword_attack");
            StartCoroutine(WaitForAnimationToFinish());       
        }
    }
    private IEnumerator WaitForAnimationToFinish() 
    {
        yield return new WaitForSeconds(3);
        hasStartedAttacking=false;
        if(!isInPersonalSpace) 
        {
        isAttacking=false;
        
        }
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

}
