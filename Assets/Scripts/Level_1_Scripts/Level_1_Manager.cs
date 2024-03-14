using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_1_Manager : EventsManager
{
    [SerializeField] string level_2_name = "Level_2";
    protected override IEnumerator FinishEvents()
    {
        Debug.Log("LOADING TUTORIAL SCENE, SHOULD CHANGE IT TO LEVEL 2");
        yield return StartCoroutine(WaitForCurrEventFinish());
        Debug.Log("level_1 EventManager has finished all its events");
       SceneManager.LoadScene(level_2_name);       
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
