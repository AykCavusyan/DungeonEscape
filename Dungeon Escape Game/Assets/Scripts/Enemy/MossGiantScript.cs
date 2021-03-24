using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MossGiantScript : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void FetchComponents()
    {
        base.FetchComponents();
        Health = base._health;
    }

    public void Damage()
    {

    }



}


