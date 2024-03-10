using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandom : MonoBehaviour
{
    [SerializeField] Mover prefabToSpawn;
    [Tooltip("determines the intensity of the sideways movement of the enemies")][SerializeField] float XIntensity;
    [Tooltip("Minimum time between consecutive spawns, in seconds")][SerializeField] float minTimeBetweenSpawns = 0.2f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")][SerializeField] float maxTimeBetweenSpawns = 1.0f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")][SerializeField] float maxXDistance = 1.5f;

    void Start()
    {
       // this.StartCoroutine(SpawnRoutine());    // co-routines
    }
    public void OnEnable() 
    {
        this.StartCoroutine(SpawnRoutine());    // co-routines

    }

    IEnumerator SpawnRoutine()
    {    // co-routines
        while (true)
        {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       // co-routines
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y,
                transform.position.z);

            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            newObject.SetActive(true);
        }
    }
}
