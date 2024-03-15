using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBossFinishScene : MonoBehaviour
{

    [SerializeField] string twistSceneName = "ds2";
    [SerializeField] Enemy enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        //enemyHealthPoints = 10;
        // healthGui.text = enemyHealthPoints.ToString();
    }
    void OnEnable() 
    { 
       //  enemyHealthPoints = 10;
//   healthGui.text = enemyHealthPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.getEnemyHP() <= 1)
        {
            SceneManager.LoadScene(twistSceneName);
        }
    }
}
