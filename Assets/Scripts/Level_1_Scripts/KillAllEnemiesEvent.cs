using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllEnemiesEvent : Event
{
    [SerializeField] Enemy[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (!enemies[i].getIsEnemyKilled())
            {
                return;
            }
        }
       // Debug.Log("killAllEnemies Event is finished");
        IsFinished();
    }
}
