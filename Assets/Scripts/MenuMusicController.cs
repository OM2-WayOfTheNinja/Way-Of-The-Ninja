using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicController : MonoBehaviour
{

    [SerializeField] AudioSource as1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MuteAndUnMute() 
    {
        as1.mute = !as1.mute;
    }
    public void UnMute() 
    { 
        as1.mute = false;

    }


}
