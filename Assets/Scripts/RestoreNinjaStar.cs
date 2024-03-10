using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreNinjaStar : MonoBehaviour
{
  //  [SerializeField] string playerTag = "Player";
    [SerializeField] CapsuleCollider playerCollider;
    [SerializeField] ShootNinjaStar NSManager;
    [SerializeField] bool isPlayerColliding = false;
    [SerializeField] int NStoRestore = 5;
    [SerializeField] ParticleSystem shineParticles;
    [SerializeField] ParticleSystem NSParticles;
    [SerializeField] GameObject NSDisplay;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other == playerCollider && isPlayerColliding == false)
        {
            isPlayerColliding = true;
            RestoreNSAndDisappear();
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

    void RestoreNSAndDisappear() 
    {
        NSManager.AddStars(NStoRestore);
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear() 
    {
        //shut off the food and shine particles:
        shineParticles.gameObject.SetActive(false);
        NSDisplay.SetActive(false);

        //invoke the hearts splat:
        var em = NSParticles.emission;
        em.burstCount = NStoRestore;
        var dur = NSParticles.duration;

        em.enabled = true;
        GetComponent<AudioSource>().Play();
        NSParticles.Play();
        yield return new WaitForSeconds(dur);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
