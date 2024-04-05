using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject asteroidPrefab;

    private int asteroidCount = 15;
    private float minCollisionDistance = 0.3f;

    private void Awake()
    {
        InitializeLevel(); 
    }

    private void InitializeLevel()
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            spawnAsteroid();
        }
    }

    private void spawnAsteroid()
    {
        bool valid;
        GameObject newAsteroid;

        do
        {
            newAsteroid = Instantiate(asteroidPrefab);
            newAsteroid.gameObject.tag = "Asteroid";
            valid = checkTooCloseToAsteroid(newAsteroid);
        } while (!valid);
    }

    private bool checkTooCloseToAsteroid(GameObject testObject)
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        foreach (GameObject asteroid in asteroids)
        {
            if (asteroid == testObject) continue;

            if (Vector3.Distance(testObject.transform.position, asteroid.transform.position) > minCollisionDistance) continue;

            Destroy(testObject);
            return false;
        }

        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
