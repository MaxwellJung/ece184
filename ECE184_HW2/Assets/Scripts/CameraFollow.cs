using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset = new Vector3(1f, 1f, 0f);
    private Transform target;
    public float followSpeed = .125f;
    public float zoomSpeed = 10f;
    private float zoom = 12f;
    public float maxZoom = 20f;
    public float minZoom = 5f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        zoom = (maxZoom + minZoom) / 2f;
        transform.position = target.position + (zoom * offset);
    }

    // Update is called once per frame
    void Update()
    {
        zoom = Mathf.Clamp(-Input.GetAxis("Mouse ScrollWheel") * zoomSpeed + zoom, minZoom, maxZoom);
        Vector3 targetPos = target.position + (zoom * offset);

        Vector3 lerpPos = Vector3.Lerp(transform.position, targetPos, followSpeed);
        transform.position = lerpPos;
        transform.LookAt(target);
    }
}
