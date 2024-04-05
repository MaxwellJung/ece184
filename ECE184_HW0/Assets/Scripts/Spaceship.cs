using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private float turnSpeed = 180;
    private Vector3 shipDirection = new Vector3(0, 1, 0);
    private float thrust = 0.05f;

    private Rigidbody2D rb;

    private float maxX = 9.2f;
    private float maxY = 5.2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float turnAngle;
        if (Input.GetKey("j"))
        {
            // turn left
            turnAngle = turnSpeed * Time.deltaTime;
            transform.Rotate(0, 0, turnAngle);
            shipDirection = Quaternion.Euler(0, 0, turnAngle) * shipDirection;
        }

        if (Input.GetKey("l"))
        {
            // turn right
            turnAngle = -turnSpeed * Time.deltaTime;
            transform.Rotate(0, 0, turnAngle);
            shipDirection = Quaternion.Euler(0, 0, turnAngle) * shipDirection;
        }

        if (Input.GetKey("k"))
        {
            // thrust
            rb.AddForce(shipDirection * thrust);
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
