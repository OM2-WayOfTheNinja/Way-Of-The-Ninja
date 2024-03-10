using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DetectStarDeflection : Event
{
    //[SerializeField] TutorialManager manager;
 
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerStartPos;
    [SerializeField] GameObject playerStartRot;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField]
    string textString =
        "Hold Right Mouse Button and move your sword to deflect all incoming ninja stars.\r\n\r\nDeflected ninja stars: ";
    [SerializeField] int starsHit = 0;
    [SerializeField] int starsToHit = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        updateText();

        startTime = 3;
        finishTime = 3;
    }
    private void OnEnable()
    {
       // Debug.Log("enableddddd");
       // player.GetComponent<Transform>().position = playerStartPos.transform.position;
       // player.GetComponent<Transform>().LookAt(playerStartRot.transform);
        // Regular null-check; this uses Unity's overloaded == operator
        if (text != null)
        {
            text.gameObject.SetActive(true);
        }
        
    }
    void updateText()
    {
       // GetComponent<TextMeshProUGUI>().text = textString + "( " + starsHit + " / " + starsToHit + " )";
        text.text = textString + "( " + starsHit + " / " + starsToHit+ " )";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeflectDetected() 
    {
        if (++starsHit >= starsToHit) 
        {
            //manager.StarsIsFinished();
            IsFinished();
        }
        updateText();
        Debug.Log("deflected: " + starsHit + " stars");
    
    
    }


private void OnDisable()
{
    if (text != null)
    {
        text.gameObject.SetActive(false);
    }
}
   
}
