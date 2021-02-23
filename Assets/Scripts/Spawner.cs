using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

    public float spawnRate = 10f;

    void Awake()
    {
        BeginSpawning();
    }

    // Update is called once per frame
    public void BeginSpawning() => StartCoroutine("Spawning");
    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(1f);

        Spawn();

        
        StartCoroutine("Spawning");
            
    }
    public GameObject Spawn()
    {
        Vector3 randomSpawn = new Vector3(Random.Range(-5, 5), 4, 0);

        var asteroid = Instantiate(asteroidPrefab, randomSpawn, Quaternion.identity);

        asteroid.SetActive(true);

        return asteroid;

        
        


    }
}