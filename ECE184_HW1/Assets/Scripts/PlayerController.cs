using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerTransform.position);
        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.position += Time.deltaTime * speed * Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerTransform.position += Time.deltaTime * speed * Vector3.right;
        }
    }

}
