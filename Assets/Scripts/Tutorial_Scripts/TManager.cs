using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TManager : EventsManager
{
    [SerializeField] DetectBamboo bambooDetector;
    [SerializeField] DetectStarDeflection starsDetector;
    [SerializeField] float bambooDeSpawnTime = 2;
    [SerializeField] float starsSpawnTime = 1;
    [SerializeField] TextMeshPro[] texts;

    [SerializeField] string gameOverSceneName = "game over";
    [SerializeField] string MenuSceneName = "Menu";
     private GameObject popup = null;
    [SerializeField] bool WEDONTNEEDAPOPUPHERE = false;
     
  

    // Start is called before the first frame update
    void Start()
    {
            popup = GameObject.Find("GameplayPopup");
        popup.SetActive(false);
        if (!WEDONTNEEDAPOPUPHERE)
        {
        popup.SetActive(true);

            Time.timeScale = 0f; // Pause game

        }
        
    
       



        StartEvents();
    }

    // Update is called once per frame
    void Update()
    {
        if(!WEDONTNEEDAPOPUPHERE){

        if (popup != null && popup.gameObject.activeSelf && (Input.anyKeyDown || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Time.timeScale = 1f; // Resume game
                popup.gameObject.SetActive(false);
            }
        }

    }

    public void BambooIsFinished()
    {
        this.StartCoroutine(WaitForSeconds(bambooDeSpawnTime, bambooDetector, starsDetector, false));
    }
    public void StarsIsFinished()
    {
        this.StartCoroutine(WaitForSeconds(bambooDeSpawnTime, starsDetector, null, true));
    }
    private IEnumerator WaitForSeconds(float seconds, MonoBehaviour scriptToDeac, MonoBehaviour scriptToAc, bool isLastEvent)
    {
        yield return new WaitForSeconds(bambooDeSpawnTime);
        if(scriptToDeac !=null)
        scriptToDeac.gameObject.SetActive(false);
        yield return new WaitForSeconds(starsSpawnTime);
        if(scriptToAc!=null)
        scriptToAc.gameObject.SetActive(true);

        if (isLastEvent) 
        {
            SceneManager.LoadScene(MenuSceneName);
        }
    }


    public void HealthReachedZero()
    {
        GameOver();
    }
    private void GameOver()
    {
       SceneManager.LoadScene(gameOverSceneName);    // Input can either be a serial number or a name; here we use name.
    }

    protected override IEnumerator FinishEvents()
    {
        yield return StartCoroutine(WaitForCurrEventFinish());
        SceneManager.LoadScene(MenuSceneName);

    }
}
