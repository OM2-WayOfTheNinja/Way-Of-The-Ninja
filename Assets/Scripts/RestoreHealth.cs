using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHealth : MonoBehaviour
{
  //  [SerializeField] string playerTag = "Player";
    [SerializeField] CapsuleCollider playerCollider;
    [SerializeField] HealthManager playerHealth;
    [SerializeField] bool isPlayerColliding = false;
    [SerializeField] int foodHPRestore = 5;
    [SerializeField] ParticleSystem shineParticles;
    [SerializeField] ParticleSystem heartsParticles;
    [SerializeField] GameObject foodDisplay;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other == playerCollider && isPlayerColliding == false)
        {
            isPlayerColliding = true;
            RestoreHealthAndDisappear();
        }
    }

    // void OnTriggerExit(Collider other) 
    // {
    //     if (other == playerCollider) // && isPlayerColliding == true)
    //     {
    //         isPlayerColliding = true;
    //         RestoreHealthAndDisappear();
    //     }
    // }

    void RestoreHealthAndDisappear() 
    {
        playerHealth.AddHealth(foodHPRestore);
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear() 
    {
        //shut off the food and shine particles:
        shineParticles.gameObject.SetActive(false);
        foodDisplay.SetActive(false);

        //invoke the hearts splat:
        var em = heartsParticles.emission;
        em.burstCount = foodHPRestore;
        var dur = heartsParticles.duration;

        em.enabled = true;
        GetComponent<AudioSource>().Play();
        heartsParticles.Play();
        yield return new WaitForSeconds(dur);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
