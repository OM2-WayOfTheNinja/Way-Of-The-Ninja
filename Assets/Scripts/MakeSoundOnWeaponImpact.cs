using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSoundOnWeaponImpact : MonoBehaviour
{
    [SerializeField] string enemyWeaponTag = "enemyWeapon";
    [SerializeField] string enemyRWeaponTag = "enemyRWeapon";
    [SerializeField] AudioClip[] starsClashSounds;
    [SerializeField] AudioClip[] swordsClashSounds;
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyWeaponTag) ) 
        {
            playSounds(swordsClashSounds); 
        }
        if (other.gameObject.CompareTag(enemyRWeaponTag)) 
        {
            playSounds(starsClashSounds); 
           
        }
    }

    void playSounds(AudioClip[] ac) 
    {
        AudioSource as1 = GetComponent<AudioSource>();
        if (as1.isPlaying) return;
        as1.clip = ac[Random.Range(0, ac.Length)];
        as1.Play();
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
