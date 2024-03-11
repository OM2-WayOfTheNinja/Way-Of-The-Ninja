using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] EventsManager manager;
    [SerializeField] TextMeshPro text;
    [SerializeField] string textString = "Health: ";
    [SerializeField] int healthPoints = 5;
    [SerializeField] bool isReducingHealth = false;
    [SerializeField] float rhCooldown = 0.5f;
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
        if (isReducingHealth == true)
        {
            return;
        }
        healthPoints = Mathf.Max(healthPoints - amount, 0);
        if (healthPoints <= 0)
        {
            manager.HealthReachedZero();
        }
        UpdateText();
        isReducingHealth = true;
        StartCoroutine(ReduceHealthCooldown());
        StartCoroutine(DamagePlayerVisuals());

        //sound when hit:
        GetComponent<AudioSource>().Play();
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
    IEnumerator ReduceHealthCooldown() 
    {
        yield return new WaitForSeconds(rhCooldown);
        isReducingHealth = false;
    }
}
