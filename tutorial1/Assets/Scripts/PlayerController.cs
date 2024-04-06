using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody rb;

    private float speed = 5f;
    private float thrust = 1f;
    
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

        // Jump
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 target = new Vector3(hit.point.x, playerTransform.position.y, hit.point.z);
            playerTransform.LookAt(target);
        }
    }
}
