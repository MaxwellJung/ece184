using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public float alivePeriod = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.forward;

        alivePeriod -= Time.deltaTime;
        if (alivePeriod <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyController>() == null)
        {
            return;
        }

        PlayerController playerController = FindObjectOfType<PlayerController>();
        playerController.UpdateScore(1);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
