using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitDetector : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] string weaponTag = "Weapon";
    [SerializeField] string rangedWeaponTag = "RWeapon";
    [SerializeField] string untaggedTag = "Untagged";
    [SerializeField] float hitCoolDownTime = 0.5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(weaponTag) )
        {
            Debug.Log("Weapon has clashed");
            enemy.WeaponDeflected();
            var colliders = GetComponents<Collider>();
            colliders[1].enabled = false;
            this.StartCoroutine(CoolDown());
        }
        if (other.gameObject.CompareTag(rangedWeaponTag))
        {
            Debug.Log("RWeapon has clashed");
            enemy.RWeaponDeflected();
            other.gameObject.tag = untaggedTag;

            //add sound when deflecting a ninja star
            GetComponent<AudioSource>().Play();
        }
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(hitCoolDownTime);
        var colliders = GetComponents<Collider>();
        colliders[1].enabled = true;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
