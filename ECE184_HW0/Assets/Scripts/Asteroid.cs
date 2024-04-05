using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;

    private float maxX = 10.15f;
    private float maxY = 6.2f;

    private float maxSpeed = 2.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), 0);

        rb.velocity = Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(Random.Range(0.5f, maxSpeed), 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if (Input.GetKey("w"))
        {
            // thrust
            rb.AddForce(new Vector2(0, 1));
        }
        if (Input.GetKey("a"))
        {
            // thrust
            rb.AddForce(new Vector2(-1, 0));
        }
        if (Input.GetKey("s"))
        {
            // thrust
            rb.AddForce(new Vector2(0, -1));
        }
        if (Input.GetKey("d"))
        {
            // thrust
            rb.AddForce(new Vector2(1, 0));
        }

        if (transform.position.x < -maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector2(-maxX, transform.position.y);
        }

        if (transform.position.y < -maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        else if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, -maxY);
        }
    }
}
