using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : Enemy, IDamageable
{
    public int Health { get; set; }
    public GameObject _acidBall;
   
    

    public override void FetchComponents()
    {
        base.FetchComponents();
        Health = base._health;
    }

    public override void Update()
    {
        
    }


    public void Damage()
    {

        Health--;

        if (Health < 1)
        {
            _anim.SetTrigger("Death");
            _isDead = true;
            GameObject _Loot = Instantiate(_loot, transform.position, Quaternion.identity);
            _Loot.GetComponent<DiamondScript>()._gems = _gems;
            GetComponent<Collider2D>().enabled = false;
        }
        
    }

    public override void EnemyPatrol()
    {
        // do not move.
    }

    public void Attack()
    {
        Instantiate(_acidBall, transform.position, Quaternion.identity);
    }
}
