using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : Enemy
{
    private void Start()
    {
        Attack();
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("Spider Attack");
    }

    public override void Update()
    {
        Debug.Log("Spider Updating");
    }
}
