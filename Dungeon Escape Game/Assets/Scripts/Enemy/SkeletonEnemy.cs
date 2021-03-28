using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void FetchComponents()
    {
        base.FetchComponents();
        Health = base._health;
    }

    public void Damage()
    {
        Health--;
        Debug.Log(Health);
        _anim.SetTrigger("Hit");
        _isHit = true;
        _anim.SetBool("InCombat", true);


        if (Health < 1)
        {
            _anim.SetTrigger("Death");
            _isDead = true;
            GameObject _Loot = Instantiate(_loot, transform.position, Quaternion.identity);
            _Loot.GetComponent<DiamondScript>()._gems = _gems;
            
        }
    }


}
