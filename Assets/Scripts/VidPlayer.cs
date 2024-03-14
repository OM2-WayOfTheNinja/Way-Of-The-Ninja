using UnityEngine.Video;
using UnityEngine;
using UnityEditor;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] string videoFileName; 
    // Start is called before the first frame update
    void Start()
    {
        PlayVideo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayVideo() 
    {
        VideoPlayer vp = GetComponent<VideoPlayer>();
    
        if (vp)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            vp.url = videoPath;
            vp.Play();
        }
    }
}
