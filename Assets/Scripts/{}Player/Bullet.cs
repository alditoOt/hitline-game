using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Boolean hitTarget = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var wall = collision.gameObject.layer;
        if (wall == 8)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetHitTarget(Boolean hitTarget) {
        this.hitTarget = hitTarget;
    }

    public Boolean IsHitTarget() {
        return hitTarget;
    }
}
