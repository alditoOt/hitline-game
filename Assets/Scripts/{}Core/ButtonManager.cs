using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void BackToMenu()
    {
        GameManager.Instance.BackToMenu();
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
