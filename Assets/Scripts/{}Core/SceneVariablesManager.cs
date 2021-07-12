using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneVariablesManager : MonoBehaviour
{
    public GameObject boss;
    public GameObject screenTransitionStart;
    public GameObject screenTransitionRestart;
    private void Start()
    {
        GameManager.Instance.GetEnemyCount(GameObject.FindGameObjectsWithTag("Enemy").Length);
        GameManager.Instance.GetOpeningWall(GameObject.FindGameObjectWithTag("OpeningWall"));
        GameManager.Instance.GetBoss(boss);
        GameManager.Instance.GetScreenTransitions(screenTransitionStart, screenTransitionRestart);
    }
}
