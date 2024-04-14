using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody rb;

    private float speed = 5f;
    private float thrust = 1f;
    private float rotationSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // WASD move
        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.position += Time.deltaTime * speed * Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerTransform.position += Time.deltaTime * speed * Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.position += Time.deltaTime * speed * Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerTransform.position += Time.deltaTime * speed * Vector3.right;
        }

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Vector3 newForce = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            if (newForce != Vector3.zero)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, newForce, Time.deltaTime * rotationSpeed, 0);
                playerTransform.LookAt(newDirection);
            }
        }

        // Jump
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
        }
    }
}
