using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    private bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            anim.SetFloat("Speed", agent.velocity.magnitude / agent.speed);
        }
    }

    public void setTrigger(string trig)
    {
        anim.SetTrigger(trig);
    }
}
