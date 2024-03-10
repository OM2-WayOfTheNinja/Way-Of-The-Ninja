using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwordFightEvent : Event
{
    [SerializeField] Enemy enemy;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
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


    // Update is called once per frame
    void Update()
    {
        if (enemy.getIsEnemyKilled()) 
        {
            Debug.Log("enemy is killed");
            text.text = "Enemy is killed";
            IsFinished();
        }
    }
}

