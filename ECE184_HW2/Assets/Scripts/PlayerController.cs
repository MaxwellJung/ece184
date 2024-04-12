using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera cam;
    private PlayerMotor motor;
    public GameObject onClickSpawn;
    public LayerMask groundMask;
    private PlayerAnimator anim;
    public GameObject fireball;
    public float castSpeed = .75f;
    public Transform spawnPoint;
    private bool canCast = true;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = transform.GetComponent<PlayerMotor>();
        anim = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, groundMask))
            {
                if (hit.transform.CompareTag("Enemy") && canCast)
                {
                    canCast = false;
                    target = hit.transform;
                    motor.Stop();
                    motor.setTarget(hit.transform);
                    anim.setTrigger("Attack");
                }
                else
                {
                    movePlayer(hit);
                }
            }
        }
    }

    void movePlayer(RaycastHit hit)
    {   
        motor.Move(hit.point);
        Instantiate(onClickSpawn, hit.point + Vector3.up * .2f, Quaternion.Euler(90, 0, 0));
    }

    void Cast()
    {
        Instantiate(fireball, spawnPoint.position, Quaternion.identity).transform.LookAt(target);
        StartCoroutine(resetCastTimer());
    }

    public IEnumerator resetCastTimer()
    {
        canCast = false;
        yield return new WaitForSeconds(castSpeed);
        canCast = true;
    }
}
