using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _speed;
    [SerializeField] protected int _gems;
    [SerializeField] protected Transform pointA, pointB;

    protected Animator _anim;
    protected SpriteRenderer _spriteRenderer;
    
    protected Vector3 _currentTarget;


    public virtual void FetchComponents()
    {
        _anim = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Start()
    {
        FetchComponents();
        _currentTarget = pointB.position;
    }

    public virtual void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        else
            EnemyPatrol();
    }


    public virtual void EnemyPatrol()
    {
        if (_currentTarget == pointA.position)
        {
            _spriteRenderer.flipX = true;
        }

        else
            _spriteRenderer.flipX = false;

        if (transform.position == pointA.position)
        {
            _anim.SetTrigger("Idle");
            _currentTarget = pointB.position;

        }

        else if (transform.position == pointB.position)
        {
            _anim.SetTrigger("Idle");
            _currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
    }

    
}
