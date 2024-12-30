using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ScreenTransitionManager : MonoBehaviour
{
    public void DisableScreen()
    {
        this.gameObject.SetActive(false);
    }

    public void DisablePlayerInput()
    {
        GameObject player = GameObject.FindWithTag("PlayerButItWorks");
        if(player != null)
        {
            player.GetComponent<PlayerInput>().enabled = false;
        }
    }

    public void EnablePlayerInput()
    {
        GameObject player = GameObject.FindWithTag("PlayerButItWorks");
        Debug.Log(player);
        Debug.Log(player.GetComponent<PlayerMovement>());
    }
}
