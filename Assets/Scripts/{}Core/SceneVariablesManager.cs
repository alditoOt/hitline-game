using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneVariablesManager : MonoBehaviour
{
    public GameObject boss;
    public GameObject screenTransitionStart;
    public GameObject pauseMenu;
    private void Start()
    {
        if(boss != null)
        {
            GameManager.Instance.GetEnemyCount(GameObject.FindGameObjectsWithTag("Enemy").Length + 1);
            GameManager.Instance.GetBoss(boss);
        }
        else
        {
            GameManager.Instance.GetEnemyCount(GameObject.FindGameObjectsWithTag("Enemy").Length);
        }
        if(pauseMenu != null)
        {
            PauseMenu.Instance.getPauseMenu(pauseMenu);
        }
        GameManager.Instance.GetOpeningWall(GameObject.FindGameObjectWithTag("OpeningWall"));
        GameManager.Instance.GetScreenTransitions(screenTransitionStart);
    }
}
