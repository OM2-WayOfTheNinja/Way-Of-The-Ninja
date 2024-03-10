using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitSplatter : MonoBehaviour
{
    [SerializeField] bool isNinjaStar = false;
    [SerializeField] float timeBetweenStarHits = 0.5f;
    [SerializeField] bool isDeflectingStar = false;
    [SerializeField] GameObject swordHitParticlesPrefab;
    [SerializeField] GameObject enemyHitParticlesPrefab;
    [SerializeField] int burstAmount = 5;
    [SerializeField] float timeToDestroy = 1.5f;
    [SerializeField] string enemyTag = "Enemy";
    [SerializeField] string enemyWeaponTag = "enemyWeapon";
    [SerializeField] string enemyRWeaponTag = "enemyRWeapon";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyWeaponTag) || other.gameObject.CompareTag(enemyRWeaponTag)) 
        {
            Debug.Log("should instansiate sparks");
            ActivateSplatter(swordHitParticlesPrefab, other);
            if (isNinjaStar)
            {
                StartCoroutine(StarDeflectCooldown());
            }
        }
        if (other.gameObject.CompareTag(enemyTag)) 
        {
            if (isNinjaStar && isDeflectingStar)
            {
                return;
            }
            Debug.Log("should instansiate blood");
            ActivateSplatter(enemyHitParticlesPrefab,other);
            
        }
    }

    void ActivateSplatter(GameObject psPrefab,Collider other) 
    {
        Vector3 impactPos = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        GameObject newPs = Instantiate(psPrefab, impactPos, Quaternion.identity);

        newPs.SetActive(true);

        //invoke the splat:        
        newPs.GetComponent<ParticleSystem>().Play();
        StartCoroutine(DeleteNewSplat(newPs));
    }

    IEnumerator DeleteNewSplat(GameObject splatObj)
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(splatObj);
    }
    IEnumerator StarDeflectCooldown()
    {
        isDeflectingStar = true;
        yield return new WaitForSeconds(timeBetweenStarHits);
        isDeflectingStar = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
