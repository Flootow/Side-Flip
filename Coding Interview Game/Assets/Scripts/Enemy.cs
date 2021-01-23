using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        EnemySpawner.Instance.EnemyCount++;
    }
    
    void Update()
    {
        //Enemy looking really dumb
    }

    private void OnDestroy()
    {
        EnemySpawner.Instance.EnemyCount--;
    }
}
