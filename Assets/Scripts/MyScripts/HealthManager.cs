using System.Collections;
using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] TManager manager;
    [SerializeField] TextMeshPro text;
    [SerializeField] string textString = "Health: ";
    [SerializeField] int healthPoints = 5;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddHealth(int amount)
    {
        healthPoints += amount;
        UpdateText();
    }
    public void ReduceHealth(int amount)
    {
        healthPoints = Mathf.Max(healthPoints - amount, 0);
        if (healthPoints <= 0)
        {
            manager.HealthReachedZero();
        }
        UpdateText();
        StartCoroutine(DamagePlayerVisuals());
    }
    private void UpdateText()
    {
        text.text = textString + healthPoints;
    }

    [SerializeField] GameObject dmgPlayerVisuals;
    [SerializeField] float dmgPlayerVisualsTime = 0.5f;
    IEnumerator DamagePlayerVisuals() 
    {
        dmgPlayerVisuals.SetActive(true);
        yield return new WaitForSeconds(dmgPlayerVisualsTime);
        dmgPlayerVisuals.SetActive(false);

    }
}
