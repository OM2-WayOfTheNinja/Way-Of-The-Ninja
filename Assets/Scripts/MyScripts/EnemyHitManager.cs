using System.Collections;
using UnityEngine;

public class EnemyHitManager : MonoBehaviour
{

    [SerializeField] string enemyRWeaponTag = "enemyRWeapon";
    [SerializeField] bool isHit = false;
    [SerializeField] float coolDownAmount = 1;
    [SerializeField] string enemyWeaponTag = "enemyWeapon";
    [SerializeField] Rigidbody rb;
    [SerializeField] float minImpulseForExplosion = 1.0f;
    [SerializeField] HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == enemyRWeaponTag)
        {
            //Debug.Log("got hit by an enemy weapon,");
            float impulse = collision.relativeVelocity.magnitude * rb.mass;
            //Debug.Log(gameObject.name + " collides with " + collision.collider.name
            //  + " at velocity " + collision.relativeVelocity + " [m/s], impulse " + impulse + " [kg*m/s]");
            if (impulse > minImpulseForExplosion)
            {
                //Debug.Log("should reduce health");
                healthManager.ReduceHealth(1);
            }

            else
            {// Debug.Log("should NOT reduce health");

            }
        }
        else if (collision.collider.gameObject.tag == enemyWeaponTag) 
        {
            if (isHit ==false)
            {
                isHit = true;
                healthManager.ReduceHealth(1);
                HitKnockback();
                StartCoroutine(SwordHitCooldown());
            }
        }
    }
    IEnumerator SwordHitCooldown() 
    {
        yield return new WaitForSeconds(coolDownAmount);
        isHit = false;
    }

    [SerializeField] float knockback = -50f;

    void HitKnockback() 
    {
        Vector3 playerKnockback = new Vector3 (0, 0, knockback);
        GetComponent<CharacterController>().Move(playerKnockback * Time.deltaTime);

    }
}
