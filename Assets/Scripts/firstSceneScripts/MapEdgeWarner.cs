using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapEdgeWarner : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] string warning = "I can't go there now, my master is waiting for me at the training area";
    [SerializeField] TextMeshPro warningText;
    [SerializeField] float warningTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            warningText.text = warning;
            warningText.gameObject.SetActive(true);
            StartCoroutine(WaitForCooldown());
        }
    }
    public IEnumerator WaitForCooldown() 
    {
        yield return new WaitForSeconds(warningTime);
            warningText.gameObject.SetActive(false);
    }
}
