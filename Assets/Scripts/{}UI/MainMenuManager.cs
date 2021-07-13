using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsMenu;
    public void ShowSettingsMenu()
    {
        settingsMenu.GetComponent<Animator>().SetBool("Show", true);
        settingsMenu.GetComponent<Animator>().SetBool("Hide", false);
        //StartCoroutine(ScreenTimer());
    }

    public void HideSettingsMenu()
    {
        settingsMenu.GetComponent<Animator>().SetBool("Show", false);
        settingsMenu.GetComponent<Animator>().SetBool("Hide", true);
    }
}
