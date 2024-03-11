using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NotifyStarHit : MonoBehaviour
{
    [SerializeField] DetectStarDeflection deflectionDetector;
    [SerializeField] string weaponTag = "Weapon";
    [SerializeField] float timeToDestroy = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == weaponTag) 
        {
            if (other.isTrigger) // the sword has 2 colliers, the trigger is for sparks, so this is for avoiding double counting 
            {
                return;
            }
            Debug.Log("stars has clashed");
            deflectionDetector.DeflectDetected();
            var colliders = GetComponents<BoxCollider>();
            colliders[1].enabled = false;
           this.StartCoroutine( DestroyStar());
        }
    }
    IEnumerator DestroyStar() 
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
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
