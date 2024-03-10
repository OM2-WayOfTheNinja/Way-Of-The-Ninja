using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(TrailRenderer))]
public class MakeSwingSound : MonoBehaviour
{
    TrailRenderer trail;
    [SerializeField] float swingMinDistance = 10;
    [SerializeField] AudioClip[] swingSounds;
    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         //calculatiing trail's length to know if the sword was swinged:
            Vector3[] trailArr; 
            trailArr = new Vector3[trail.GetComponent<TrailRenderer>().positionCount]; 
            trail.GetComponent<TrailRenderer>().GetPositions(trailArr);
            float dist = trailArr.Length == 0? 0 : Vector3.Distance(trailArr[trailArr.Length-1],trailArr[0]);
        if (dist > swingMinDistance)
        {
            AudioSource swingSound = GetComponent<AudioSource>();
            if (swingSound.isPlaying == false)
            {
                swingSound.clip = swingSounds[Random.Range(0,swingSounds.Length)];
                swingSound.Play();
            }
           // Debug.Log("swwaaaang with: " + dist);
        }
        
    }
}
