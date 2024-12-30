using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerButItWorks"))
        {
            GameManager.Instance.NextFloor();
            Destroy(this.gameObject);
        }
    }
}
