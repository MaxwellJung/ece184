using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform playerTransform;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (null != playerTransform)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, Time.deltaTime * speed);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == null)
        {
            return;
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
