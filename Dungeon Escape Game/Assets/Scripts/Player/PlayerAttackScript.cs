using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerAttackScript : MonoBehaviour
{
   [SerializeField ]private bool _canHit = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
   
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null && _canHit == true)
        {
                hit.Damage();
                StartCoroutine(CanHitCheck());
        }

        IEnumerator CanHitCheck()
        {
            _canHit = false;
            yield return new WaitForSeconds(0.5f);
            _canHit = true;
        }

    }

     

}
