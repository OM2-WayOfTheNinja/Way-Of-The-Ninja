//using UnityEditorInternal;
using UnityEngine;

/**
 * This component patrols between given points, chases a given target object when it sees it, and rotates from time to time.
 */
[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Chaser))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(SwordAttackScript))]


public class EnemyControllerStateMachine : StateMachine
{
    [SerializeField] float radiusToWatch = 5f;
    [SerializeField] float probabilityToRotate = 0.2f;
    [SerializeField] float probabilityToStopRotating = 0.2f;

    private Chaser chaser;
    private Patroller patroller;
    private Rotator rotator;
    private SwordAttackScript swordAttackScript;

    private float DistanceToTarget() {
        //Debug.Log(" distance is: " + Vector3.Distance(transform.position, chaser.TargetObjectPosition()));
        return Vector3.Distance(transform.position, chaser.TargetObjectPosition());
    }

    private bool IsTooClose() 
    {
      return chaser.IsTooClose();
    }
    private bool IsAttacking() 
    {
        return swordAttackScript.IsAttacking();
    }

    private void Awake() {
        chaser = GetComponent<Chaser>();
        patroller = GetComponent<Patroller>();
        rotator = GetComponent<Rotator>();
        swordAttackScript = GetComponent<SwordAttackScript>();
        base
        .AddState(patroller)     // This would be the first active state.
        .AddState(chaser)
        .AddState(rotator)
        .AddState(swordAttackScript)
        .AddTransition(chaser, () => IsTooClose(), swordAttackScript)
        .AddTransition(swordAttackScript, () => IsAttacking() , patroller)
        .AddTransition(patroller, () => DistanceToTarget() <= radiusToWatch, chaser)
        .AddTransition(rotator, () => DistanceToTarget() <= radiusToWatch, chaser)
        .AddTransition(chaser, () => DistanceToTarget() > radiusToWatch, patroller)
        .AddTransition(rotator, () => Random.Range(0f, 1f) < probabilityToStopRotating * Time.deltaTime, patroller)
        .AddTransition(patroller, () => Random.Range(0f, 1f) < probabilityToRotate * Time.deltaTime, rotator)
        ;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusToWatch);
    }
}
