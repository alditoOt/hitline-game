using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDistance : MonoBehaviour
{
    private Transform target;
    public float desiredDistance;

    private Animator anim;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, target.position) < desiredDistance)
        {
            anim.SetBool("Close", true);
        }
        else
        {
            anim.SetBool("Close", false);
        }
    }
}
