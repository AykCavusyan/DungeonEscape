using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    SpiderEnemy _spiderEnemyScript;


    public void Start()
    {
        _spiderEnemyScript = GetComponentInParent<SpiderEnemy>();
       
    }


    public void Fire()
    {
       
        Debug.Log("Spider Should Fire");
        _spiderEnemyScript.Attack();


    }
}
