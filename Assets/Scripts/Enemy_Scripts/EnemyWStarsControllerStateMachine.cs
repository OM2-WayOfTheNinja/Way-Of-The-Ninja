//using UnityEditorInternal;
using UnityEngine;

/**
 * This component patrols between given points, chases a given target object when it sees it, and rotates from time to time.
 */
[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(SwordAttackScript))]


public class EnemyWStarsControllerStateMachine : StateMachine
{
    [SerializeField] float radiusToWatch = 5f;
    [SerializeField] float probabilityToRotate = 0.2f;
    [SerializeField] float probabilityToStopRotating = 0.2f;

    private Shooter shooter;
    private Patroller patroller;
    private Rotator rotator;
    private SwordAttackScript swordAttackScript;

    private float DistanceToTarget() {
        //Debug.Log(" distance is: " + Vector3.Distance(transform.position, chaser.TargetObjectPosition()));
        return Vector3.Distance(transform.position, shooter.TargetObjectPosition());
    }

    private bool IsTooClose() 
    {
      return shooter.IsTooClose();
    }
    private bool IsAttacking() 
    {
        return swordAttackScript.IsAttacking();
    }

    private void Awake() {
        shooter = GetComponent<Shooter>();
        patroller = GetComponent<Patroller>();
        rotator = GetComponent<Rotator>();
        swordAttackScript = GetComponent<SwordAttackScript>();
        base
        .AddState(patroller)     // This would be the first active state.
        .AddState(shooter)
        .AddState(rotator)
        .AddTransition(patroller, () => DistanceToTarget() <= radiusToWatch, shooter)
        .AddTransition(rotator, () => DistanceToTarget() <= radiusToWatch, shooter)
        .AddTransition(shooter, () => DistanceToTarget() > radiusToWatch, patroller)
        .AddTransition(rotator, () => Random.Range(0f, 1f) < probabilityToStopRotating * Time.deltaTime, patroller)
        .AddTransition(patroller, () => Random.Range(0f, 1f) < probabilityToRotate * Time.deltaTime, rotator)
        ;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusToWatch);
    }
}
