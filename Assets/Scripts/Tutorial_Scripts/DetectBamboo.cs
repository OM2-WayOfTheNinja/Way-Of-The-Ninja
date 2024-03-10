using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectBamboo : Event
{
    [SerializeField]  TManager manager;
    [SerializeField] TextMeshProUGUI text;
    
    [SerializeField] string textString =
        "Hold Left Mouse Button and move your sword to slice and knock down all the bamboo pieces.\r\n\r\nSliced and knocked bamboo pieces: ";
    [SerializeField] int touchedBamboo = 0;
    [SerializeField] int bamboosToTouch = 5;
    [SerializeField] string bambooTag = "bamboo";
    // Start is called before the first frame update
    void Start()
    {
        startTime = 3;
        finishTime = 3;
        updateText();
    }

  private void OnEnable()
{
    // Regular null-check; this uses Unity's overloaded == operator
    if (text != null)
    {
        text.gameObject.SetActive(true);
    }
}

private void OnDisable()
{
    // Regular null-check, which correctly handles Unity's destroyed objects
    if (text != null)
    {
        text.gameObject.SetActive(false);
    }
}


    void updateText() 
    {
        text.text = textString + "( " + touchedBamboo + " / " + bamboosToTouch + " )";
        text.text.Replace("\\n", "\n"); 
    }
    // Update is called once per frame
    void Update()
    {
        if (touchedBamboo >= bamboosToTouch) 
        {
            IsFinished();
           // manager.BambooIsFinished();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == bambooTag) 
        {
            touchedBamboo++;
            updateText();

        }
    }

   
}
