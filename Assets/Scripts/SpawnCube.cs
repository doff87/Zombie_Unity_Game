using System.Collections;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    //What are we instantiating?
    [SerializeField] GameObject cubePrefab;
    //From Where?
    [SerializeField] Transform spawnLocation;
    //Minimum time to spawn
    [SerializeField] float minimumTimeToSpawn;
    //Maximum time to spawn
    [SerializeField] float maximumTimeToSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCubeCoroutine());
    }

    IEnumerator SpawnCubeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minimumTimeToSpawn, maximumTimeToSpawn));

            Instantiate(cubePrefab, spawnLocation.position, spawnLocation.rotation);
        }
    }
}
