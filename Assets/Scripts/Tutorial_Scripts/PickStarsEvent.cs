using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickStarsEvent : Event
{
        [SerializeField] GameObject NSDisplay;
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] string textString =
        "Touch the ninja stars to pick them up";
 


    // Start is called before the first frame update
    void Start()
    {
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (NSDisplay.active == false)
        {
            Debug.Log("pickup finished");
            IsFinished();
        }
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
        text.text = textString ;
    }
}
