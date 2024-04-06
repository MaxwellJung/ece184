using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject cube;
    public GameObject player;

    private float radius = 3f;

    public void SpawnCube()
    {
        Vector3 spawnLocation = player.transform.position + radius * Random.onUnitSphere;
        spawnLocation.y = Mathf.Abs(spawnLocation.y);
        Instantiate(cube, spawnLocation, Quaternion.identity);
    }
}
