using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneVariablesManager : MonoBehaviour
{
    public GameObject boss;
    public GameObject screenTransitionStart;
    public TextMeshProUGUI text;
    private void Start()
    {
        GameManager.Instance.GetEnemyCount(GameObject.FindGameObjectsWithTag("Enemy").Length);
        GameManager.Instance.GetOpeningWall(GameObject.FindGameObjectWithTag("OpeningWall"));
        GameManager.Instance.GetBoss(boss);
        GameManager.Instance.GetScreenTransitions(screenTransitionStart);
        TimerManager.Instance.GetText(text);
    }

    public void BackToMenu()
    {
        screenTransitionStart.gameObject.SetActive(true);
        AudioManager.Instance.Play("Shoot");
    }

    public void StartGame()
    {
        screenTransitionStart.gameObject.SetActive(true);
        AudioManager.Instance.Play("Shoot");
    }

    public void QuitGame()
    {
        AudioManager.Instance.Play("Shoot");
        Application.Quit();
    }

    public void BeginTimer()
    {
        TimerManager.Instance.BeginTimer();
    }
}
