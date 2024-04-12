using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    private NavMeshAgent agent;

    private Transform target;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
            Quaternion lerpRot = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);
            transform.rotation = lerpRot;
        }
    }

    public void Move(Vector3 location)
    {
        nullTarget();
        agent.isStopped = false;
        agent.SetDestination(location);
    }

    public void Stop()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
    }

    public void setTarget(Transform t)
    {
        target = t;
    }

    public void nullTarget()
    {
        target = null;
    }
}
