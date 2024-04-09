using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 5f;
    public GameObject bulletPrefab;
    public TMP_Text scoreText;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerTransform.position);
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

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, playerTransform.position, playerTransform.rotation);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 target = new Vector3(hit.point.x, playerTransform.position.y, hit.point.z);
            playerTransform.LookAt(target);
        }
    }

    public void UpdateScore(int increment)
    {
        score += increment;
        scoreText.text = $"Score: {score}";
    }
}
