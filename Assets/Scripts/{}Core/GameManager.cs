using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private static int enemyCount;
    private void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
       
    }
    public void EnemyDead()
    {
        enemyCount--;
        if(enemyCount <= 0)
        {
            Debug.Log("OH MY GOD EVERYONE'S DEAD");
        }
    }
}
