using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneManager : EventsManager
{
    [SerializeField] string nextScene = "Menu";

    protected override IEnumerator FinishEvents()
    {
        SceneManager.LoadScene(nextScene);
        yield return StartCoroutine(WaitForCurrEventFinish());
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
