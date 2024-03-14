using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable() 
    {
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
