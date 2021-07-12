using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestart : MonoBehaviour
{
    private PlayerDead deadScript;

    private void Start()
    {
        deadScript = GetComponent<PlayerDead>();
    }

    void OnRestart()
    {
        if(deadScript.dead)
        {
            GameManager.Instance.RestartFloor();
            AudioManager.Instance.Play("Restart");
        }
    }
}
