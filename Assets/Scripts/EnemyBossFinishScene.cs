using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBossFinishScene : Enemy
{

    [SerializeField] string twistSceneName = "ds2";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealthPoints <= 1)
        {
            SceneManager.LoadScene(twistSceneName);
        }
    }
}
