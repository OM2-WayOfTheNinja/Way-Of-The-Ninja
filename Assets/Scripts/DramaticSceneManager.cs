using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DramaticSceneManager : MonoBehaviour
{
    [SerializeField] VideoPlayer vp;
    [SerializeField] Boolean cooldown = false;
    [SerializeField] float waitForCooldown = 0.5f;
    [SerializeField] string nextScene = "First Scene";
    // Start is called before the first frame update

    void Awake() 
    {
       // vp.Play();
    }
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // vp.Play();
        StartCoroutine(WaitForCooldown());
    }

    IEnumerator WaitForCooldown()
    {
        yield return new WaitForSeconds(waitForCooldown);
        cooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!vp.isPlaying && cooldown)
        {
            SceneManager.LoadScene(nextScene);
        }
            
    }

    public void SkipVideo() 
    {
        if (!cooldown)
        {
            return;
        }
        SceneManager.LoadScene(nextScene);
    }

}
