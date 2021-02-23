using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{

    public GameObject asteroidPrefab;

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(asteroidPrefab);
    }
}
