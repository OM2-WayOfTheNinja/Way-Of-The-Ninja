using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootNinjaStar : MonoBehaviour
{
    [SerializeField] GameObject starStartPosRef;
    [SerializeField] GameObject starPrefab;
    
     [SerializeField] TextMeshPro text;
    [SerializeField] string textString = "Ninja stars: ";

   // [SerializeField] GameObject starVisuals;
    [SerializeField] int starsAmount = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();   
    }

    public void AddStars(int number) 
    { starsAmount += number;
    UpdateText(); }
    public void ReduceStars(int number)
    { 
        starsAmount -= number;
        starsAmount = starsAmount < 0 ? 0 : starsAmount;
    UpdateText();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true && starsAmount > 0)
        {
            Vector3 positionOfSpawnedStar = starStartPosRef.transform.position;

            GameObject starToShoot = Instantiate(starPrefab.gameObject, positionOfSpawnedStar, Quaternion.identity);
            starToShoot.SetActive(true);
            --starsAmount;
            UpdateText();
        }
    }

    public void UpdateText()
    {
        text.text = textString + starsAmount;
    }
}
