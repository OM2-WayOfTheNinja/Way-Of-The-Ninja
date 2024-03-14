using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event : MonoBehaviour
{
    [SerializeField] EventsManager eventsManager;
    [SerializeField] protected float startTime = 3, finishTime = 3;
    [SerializeField] bool calledIsFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IsFinished()
    {

        if (calledIsFinished == false) 
        {
        Debug.Log("in ISIFINISHED");
        StartCoroutine( eventsManager.CurrEventFinished());
        calledIsFinished = true;
        
        }
    }

    public float GetStartTime()
    {
        return startTime;
    }
    public float GetFinishTime()
    {
        return finishTime;
    }

    public void setCalledIsFinished(bool value) 
    {
        calledIsFinished = value;
    }
}
