using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MossGiantScript : Enemy
{
    //private bool _switch;
    private Vector3 _currentTarget;
    private bool _flip = false;

    private void Start()
    {
        FetchComponents();
        _currentTarget = pointB.position;
    }

    public override void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        else
            Movement();
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            _flip = false;
            StartCoroutine(FlipRoutine());
            _currentTarget = pointB.position;
        }

        else if (transform.position == pointB.position)
        {
            _flip = true;
            StartCoroutine(FlipRoutine());
            _currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
        
    }

    IEnumerator FlipRoutine()
    {
        _anim.SetTrigger("Idle");
        yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        _spriteRenderer.flipX = _flip;
    }
}


