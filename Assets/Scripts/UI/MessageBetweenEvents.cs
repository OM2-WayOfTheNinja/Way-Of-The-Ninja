using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MessageBetweenEvents : Event
{
    [SerializeField] private TextMeshProUGUI text;
    
   

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

    private void OnEnable()
    {
        // Activate the TextMeshProUGUI object if it exists
        if (text != null)
        {
            text.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        // Deactivate the TextMeshProUGUI object if it exists
        if (text != null)
        {
            text.gameObject.SetActive(false);
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
