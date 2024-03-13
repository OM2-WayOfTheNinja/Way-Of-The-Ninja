using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : Event
{
     

    // Start is called before the first frame update
    void Start()
    {
        // Play the audio clip if an AudioSource component exists
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource component is missing!");
        }
    }

   


    // Update is called once per frame
    void Update()
    {
        // Check if the audio has finished playing
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && !audioSource.isPlaying)
        {
            IsFinished();
        }
    }
  
}
