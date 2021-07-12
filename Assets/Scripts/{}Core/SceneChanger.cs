using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour
{
    public void NextFloor()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartFloor()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DisableScreen()
    {
        this.gameObject.SetActive(false);
    }

    public void DisablePlayerInput()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            player.GetComponent<PlayerInput>().enabled = false;
        }
    }

    public void EnablePlayerInput()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().enabled = true;
    }
}
