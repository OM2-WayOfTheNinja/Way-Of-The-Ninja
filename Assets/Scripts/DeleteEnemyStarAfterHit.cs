using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEnemyStarAfterHit : MonoBehaviour
{
      [SerializeField] string weaponTag = "Weapon";
      [SerializeField] string RweaponTag = "RWeapon";
    [SerializeField] float timeToDestroy = 2;
    private void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.CompareTag(weaponTag) || other.gameObject.CompareTag(RweaponTag)) 
        // {
        //     Debug.Log("stars has clashed");
        //     var colliders = GetComponents<BoxCollider>();
        //     colliders[1].enabled = false;
        // }
           this.StartCoroutine( DestroyStar());
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
