using UnityEngine;
using TMPro;
using System;


public class Clock : MonoBehaviour
{
    [SerializeField] private Transform clockHourHandTransform;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float startTimeInSeconds = 60f;
    private float clockRotationSpeed = 6f; // Degrees per second for clock rotation
    private float secondsPerMinute = 60f;

   // public event EventHandler OnTimeOverEvent;
    public EventsManager OnTimeOverEvent;


    private float remainingSeconds;
    private float timeFromLastScene;
    private void Start()
    {
        // Reset the start time when the scene is loaded
        startTimeInSeconds = Time.time + startTimeInSeconds;
        timeFromLastScene = Time.time;

    }
    private void Update()
    {
        // Time calculation
        remainingSeconds = startTimeInSeconds - Time.time;
        if (remainingSeconds > 0)
        {
            clockHourHandTransform.Rotate(Vector3.forward, clockRotationSpeed * Time.deltaTime);
            int minutes = Mathf.FloorToInt(remainingSeconds / secondsPerMinute);
            int seconds = Mathf.FloorToInt(remainingSeconds % secondsPerMinute);

            string minutesString = minutes.ToString("00");
            string secondsString = seconds.ToString("00");

            timeText.text = minutesString + ":" + secondsString;
        }
        else
        {
            timeText.text = "00:00";
            OnTimeOverEvent.CurrEventFinished();
        }
    }

    public float GetSecondsRemaining()
    {
        return remainingSeconds;
    }

    public float GetTotalTime() {
        return startTimeInSeconds - timeFromLastScene;
    }

}
