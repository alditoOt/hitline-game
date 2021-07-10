using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectTrigger : MonoBehaviour
{
    public bool playerShootTrigger = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerPosition"))
        {
            anim.ResetTrigger("InspectTrigger");
            anim.SetTrigger("InspectTrigger");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerPosition"))
        {
            anim.ResetTrigger("InspectTrigger");
        }
    }
}
