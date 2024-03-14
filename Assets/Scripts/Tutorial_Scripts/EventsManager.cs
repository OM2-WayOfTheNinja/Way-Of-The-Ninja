using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class EventsManager : MonoBehaviour
{

    [SerializeField] protected Event[] events;
    [SerializeField] protected int currEvent = 0;
    [SerializeField] protected bool isCurrEventFinishedRunning = false;
    [SerializeField] string gameOverSceneName = "GameOverScene";


    public bool GetIsCurrEventFinishedRunning() { return isCurrEventFinishedRunning;}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void StartEvents()
    {
        if (events != null)
        {
            if (events[0]!=null)
            events[0].gameObject.SetActive(true);
            for (int i = 1; i < events.Length; i++)
            {
                if (events[i]!=null)
                events[i].gameObject.SetActive(false);

            }
        }
    }

    // public abstract bool IsFinished();
    protected void NextEvent() 
    {
        TurnOffCurrEvent();
        TurnOnNextEvent();
       
    }

    protected IEnumerator TurnOffCurrEvent()
    {
        Debug.Log("in TurnOffCurrEvent");
        events[currEvent++].gameObject.SetActive(false);
        float currStartTime = 0.01f;
        if (currEvent < events.Length && events[currEvent] != null)
        {
            currStartTime = events[currEvent].GetStartTime();
        }
        yield return new WaitForSeconds(currStartTime);
        Debug.Log("before calling TurnOnNextEvent");
        TurnOnNextEvent();
    }
    protected void TurnOnNextEvent()
    {
        Debug.Log("in TurnOnNextEvent");
        Debug.Log("after calling TurnOnNextEvent");
        isCurrEventFinishedRunning = false;
        Debug.Log("iscurreventfinished: " + isCurrEventFinishedRunning);

        if (currEvent < events.Length && events[currEvent] != null) 
        {
            Debug.Log("turning on next event");
            events[currEvent].setCalledIsFinished(false);
            events[currEvent].gameObject.SetActive(true);
        }
        else //reached final event 
        {
            StartCoroutine( FinishEvents());
        }
    }

    protected abstract IEnumerator FinishEvents();
    public IEnumerator CurrEventFinished() 
    {
        isCurrEventFinishedRunning = true;
        Debug.Log("iscurreventfinished: " + isCurrEventFinishedRunning);
        float currFinishTime = 0;
        currFinishTime = events[currEvent].GetStartTime();
        yield return new WaitForSeconds(currFinishTime);
        StartCoroutine( TurnOffCurrEvent());
    }

    protected IEnumerator WaitForCurrEventFinish()
    {
        float currFinishTime = 0;
        currFinishTime = events[currEvent-1].GetStartTime();
        yield return new WaitForSeconds(currFinishTime);
    }
    protected IEnumerator WaitForCurrEventStart()
    {
        Debug.Log("in WaitForCurrEventStart");
        float currStartTime = 0.01f;
        if (currEvent < events.Length && events[currEvent] != null) 
        {
            currStartTime = events[currEvent].GetStartTime();
        }
        yield return new WaitForSeconds(currStartTime);
        Debug.Log("exiting WaitForCurrEventStart");

    }

    public void HealthReachedZero()
    {
        GameOver();
    }
     private void GameOver()
    {
       SceneManager.LoadScene(gameOverSceneName);    // Input can either be a serial number or a name; here we use name.
    }
}
